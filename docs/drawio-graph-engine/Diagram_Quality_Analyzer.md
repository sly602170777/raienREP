# Diagram Quality Analyzer（图质量分析器）

## 一、模块目标

Diagram Quality Analyzer（图质量分析器）用于在 Parser 之后、Rule Engine 之前，对 draw.io 图进行质量检查。

它的核心目标不是直接生成业务结果，而是回答一个问题：

```text
这张 draw.io 图是否足够规范，能否被后续 Rule Engine 和 Analyzer 稳定识别？
```

在现场开发中，历史 draw.io 图经常存在以下问题：

```text
节点命名不统一
节点类型不明确
连线没有 label
连线方向混乱
孤立节点较多
重复连线较多
图片里包含关键文字但 XML 无法读取
不同页面画图规范不一致
```

因此，本模块应该先帮助开发者发现问题，再决定是否需要修改 draw.io 图。

---

## 二、模块位置

整体流程如下：

```text
draw.io XML
    ↓
Parser
    ↓
nodes.csv / edges.csv
    ↓
Diagram Quality Analyzer
    ↓
quality_report.csv
unknown_nodes.csv
invalid_edges.csv
isolated_nodes.csv
duplicate_edges.csv
    ↓
Rule Engine
    ↓
Business Graph
    ↓
Analyzer
    ↓
relations.csv / report.xlsx / SQLite / AI Analysis
```

注意：

```text
Parser 只负责解析 XML。
Quality Analyzer 负责检查图是否规范。
Rule Engine 负责解释业务含义。
Analyzer 负责生成业务结果。
```

这几个职责不要混在一起。

---

## 三、输入文件

Diagram Quality Analyzer 的第一版输入文件为：

```text
nodes.csv
edges.csv
```

其中：

```text
nodes.csv 代表所有节点
edges.csv 代表所有连线
```

这两个文件由 Parser 生成。

---

## 四、输出文件

建议第一版输出以下文件：

```text
quality_report.csv
unknown_nodes.csv
invalid_edges.csv
isolated_nodes.csv
duplicate_edges.csv
missing_label_edges.csv
```

其中最重要的是：

```text
quality_report.csv
```

它是整个图的汇总质量报告。

---

## 五、quality_report.csv 设计

### 5.1 字段设计

推荐字段：

```csv
file_name,page,metric,category,severity,count,total,ratio,score,message,suggestion
```

字段说明：

| 字段 | 说明 |
|---|---|
| file_name | 来源 draw.io XML 文件名 |
| page | 页面名，整体统计可使用 ALL |
| metric | 指标名称 |
| category | 指标分类 |
| severity | 严重程度：INFO / WARNING / ERROR |
| count | 问题数量 |
| total | 统计总数 |
| ratio | 问题比例 |
| score | 分数，0～100 |
| message | 问题说明 |
| suggestion | 修改建议 |

### 5.2 示例

```csv
file_name,page,metric,category,severity,count,total,ratio,score,message,suggestion
sample.drawio.xml,ALL,unknown_node_ratio,node,WARNING,12,100,0.12,88,存在未识别节点,建议补充 KEY: / VALUE: / API: 等前缀
sample.drawio.xml,ALL,missing_edge_label_ratio,edge,WARNING,20,80,0.25,75,部分连线缺少 label,建议为关键连线补充 HAS / CALLS / RETURNS 等关系名
sample.drawio.xml,ALL,invalid_edge_count,edge,ERROR,2,80,0.025,60,存在 source 或 target 不存在的连线,建议检查 draw.io 中是否有断开的连接器
```

---

## 六、建议检查指标

### 6.1 Node 类指标

| 指标 | 说明 |
|---|---|
| total_nodes | 节点总数 |
| unknown_node_count | 未识别节点数量 |
| unknown_node_ratio | 未识别节点比例 |
| empty_text_node_count | 空文本节点数量 |
| duplicate_node_text_count | 重复节点文本数量 |
| isolated_node_count | 孤立节点数量 |
| image_node_count | 图片节点数量 |

### 6.2 Edge 类指标

| 指标 | 说明 |
|---|---|
| total_edges | 连线总数 |
| invalid_edge_count | source 或 target 不存在的连线数量 |
| missing_edge_label_count | 缺少 label 的连线数量 |
| missing_edge_label_ratio | 缺少 label 的连线比例 |
| duplicate_edge_count | 重复连线数量 |
| self_loop_edge_count | 自循环连线数量 |
| unknown_relation_count | 未识别关系数量 |

### 6.3 Page 类指标

| 指标 | 说明 |
|---|---|
| total_pages | 页面总数 |
| page_node_count | 每页节点数量 |
| page_edge_count | 每页连线数量 |
| page_unknown_ratio | 每页未识别比例 |
| page_quality_score | 每页质量分数 |

---

## 七、评分设计

第一版可以采用简单评分模型：

```text
quality_score = 100
  - unknown_node_ratio * 30
  - missing_edge_label_ratio * 20
  - invalid_edge_ratio * 30
  - isolated_node_ratio * 10
  - duplicate_edge_ratio * 10
```

最终分数限制在：

```text
0 ～ 100
```

建议评分解释：

| 分数 | 说明 |
|---|---|
| 90～100 | 图质量较好，可以直接进入 Rule Engine |
| 75～89 | 图基本可用，但建议修正部分标记 |
| 60～74 | 图可解析，但业务分析结果可能不稳定 |
| 0～59 | 图质量较差，建议先修改 draw.io 图 |

---

## 八、严重程度定义

### INFO

信息提示，不一定需要修改。

例如：

```text
节点总数
页面总数
图片节点数量
```

### WARNING

建议修改，否则后续分析准确率可能下降。

例如：

```text
未识别节点较多
缺少连线 label
孤立节点较多
```

### ERROR

明显结构问题，建议优先处理。

例如：

```text
连线 source 不存在
连线 target 不存在
XML 结构不完整
```

---

## 九、修改建议生成规则

Quality Analyzer 不应该只告诉用户“有问题”，还应该给出修改建议。

示例：

| 问题 | 建议 |
|---|---|
| UNKNOWN 节点 | 为节点增加 KEY: / VALUE: / API: / SCREEN: 等前缀 |
| Edge 缺少 label | 为关键连线增加 HAS / CALLS / RETURNS / CONTAINS 等关系名 |
| 孤立节点 | 检查是否忘记连接，或将其标记为 NOTE |
| 图片节点 | 如果图片中有关键字，建议改成 draw.io 文本节点，或后续使用 OCR |
| 重复 Edge | 删除重复连线，或确认是否代表不同关系 |

---

## 十、与 Rule Engine 的关系

Quality Analyzer 和 Rule Engine 的区别：

| 模块 | 主要职责 |
|---|---|
| Quality Analyzer | 判断图是否规范、是否容易被分析 |
| Rule Engine | 根据规则解释节点和关系的业务含义 |

Quality Analyzer 可以依赖 Rule Engine 的初步结果，例如：

```text
node_type = UNKNOWN
relation = UNKNOWN
```

但 Quality Analyzer 不应该直接替代 Rule Engine。

---

## 十一、第一版实现范围

第一版建议实现：

```text
读取 nodes.csv
读取 edges.csv
统计总节点数
统计总连线数
统计 UNKNOWN 节点
统计 invalid edges
统计 missing label edges
统计 isolated nodes
统计 duplicate edges
生成 quality_report.csv
```

暂不实现：

```text
AI 自动修复建议
OCR 图片文字识别
复杂布局判断
跨页面引用分析
Neo4j 质量分析
```

---

## 十二、后续扩展方向

后续可以增加：

```text
fix_suggestions.csv
page_quality_report.csv
style_consistency_report.csv
naming_convention_report.csv
AI_quality_review.md
```

其中 `fix_suggestions.csv` 可以细化到具体节点和连线：

```csv
file_name,page,item_type,item_id,current_value,issue,suggestion
sample.drawio.xml,Page_1,node,n12,ProductA,UNKNOWN节点,建议改为 KEY:ProductA
sample.drawio.xml,Page_1,edge,e8,,缺少关系label,建议增加 HAS 或 CONTAINS
```

---

## 十三、推荐开发顺序

在当前项目中，建议开发顺序调整为：

```text
1. Architecture.md
2. Graph_Model.md
3. Parser
4. Diagram Quality Analyzer
5. Rule Engine
6. Analyzer
7. AI Analysis
```

原因：

```text
如果图本身质量不稳定，再好的业务规则也会受到影响。
```

先做质量分析，可以更快发现历史图中的不规范问题，并减少后续业务分析的误判。
