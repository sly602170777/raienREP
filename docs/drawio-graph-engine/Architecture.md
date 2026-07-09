# Draw.io Graph Engine Architecture

## 1. Purpose

This project is designed for on-site software development work where draw.io diagrams contain business knowledge such as API relationships, screen flows, request/response structures, key-value mappings, database mappings, and other relationship-heavy information.

The goal is not to convert draw.io directly into Markdown. The goal is to treat draw.io XML as a structured source file and compile it into stable, analyzable outputs.

```text
draw.io XML
  -> Parser
  -> Raw Graph
  -> Normalizer
  -> Rule Engine
  -> Business Graph
  -> Analyzer
  -> CSV / Excel / SQLite / AI Summary
```

## 2. Compiler-style design

This project should be designed like a small compiler, not like a one-off script.

| Compiler concept | This project |
|---|---|
| Source code | draw.io XML |
| Parser | XML to nodes and edges |
| AST / IR | Graph model |
| Semantic analysis | Business rule engine |
| Output target | CSV, Excel, SQLite, reports |

This separation keeps XML parsing generic while allowing business rules to evolve independently.

## 3. Layer design

### 3.1 Input layer

First supported input:

```text
.drawio exported as uncompressed XML
```

Future inputs may include compressed draw.io XML, JSON export, SVG metadata, OCR extracted image text, Mermaid, and PlantUML.

### 3.2 Parser layer

The parser only reads draw.io XML and extracts raw graph data. It should not decide business meaning.

Parser output:

```text
nodes.csv
edges.csv
```

Typical draw.io mapping:

```text
mxCell vertex="1" -> Node
mxCell edge="1"   -> Edge
```

### 3.3 Normalizer layer

The normalizer cleans raw data:

```text
remove HTML tags
unescape HTML entities
normalize whitespace
extract geometry
preserve style and raw text
```

Unknown data should be preserved for quality checks.

### 3.4 Rule Engine layer

The rule engine converts raw graph data into business graph data.

Examples:

```text
KEY:ProductA   -> node_type = KEY
VALUE:Red      -> node_type = VALUE
API:Login      -> node_type = API
SCREEN:Login   -> node_type = SCREEN
```

Relation examples:

```text
KEY -> VALUE       -> HAS
SCREEN -> API      -> CALLS
API -> RESPONSE    -> RETURNS
TABLE -> COLUMN    -> HAS_COLUMN
```

Business rules should be stored outside Python code, for example:

```text
rules/default_rules.json
```

### 3.5 Analyzer layer

The analyzer generates business-specific outputs.

First supported analyzer:

```text
KEY / VALUE many-to-many relation extraction
```

Future analyzers:

```text
API field list
screen-to-api mapping
request/response mapping
database table/column mapping
impact analysis
unknown node report
duplicate relation report
isolated node report
```

### 3.6 Exporter layer

First supported output:

```text
CSV
```

Future outputs:

```text
Excel
SQLite
JSON
Markdown report
HTML report
```

### 3.7 AI analysis layer

AI should not be used as the first parser. The deterministic parser and rule engine should run first.

AI is better used after graph extraction:

```text
summarize business flow
explain API dependencies
classify unknown nodes
suggest missing relations
generate developer notes
produce impact analysis explanation
```

## 4. Recommended repository structure

```text
docs/
  drawio-graph-engine/
    Architecture.md
    Graph_Model.md

rules/
  default_rules.json

src/
  drawio_graph_engine/
    __init__.py
    parser.py
    normalizer.py
    rule_engine.py
    analyzer.py
    exporter.py
    cli.py

examples/
  input/
  output/

tests/
```

## 5. Development roadmap

### Milestone 1: Architecture docs

Create architecture and graph model documents.

### Milestone 2: First parser

Create a parser that reads uncompressed draw.io XML and outputs:

```text
nodes.csv
edges.csv
```

### Milestone 3: Rule engine

Add configurable node and edge recognition rules.

Output:

```text
business_nodes.csv
business_edges.csv
unknown_nodes.csv
invalid_edges.csv
```

### Milestone 4: Analyzer

Generate business-specific output.

First target:

```text
relations.csv
```

### Milestone 5: On-site usage workflow

```text
1. Export draw.io as uncompressed XML
2. Run parser
3. Review nodes.csv and edges.csv
4. Add or refine rules
5. Generate relations.csv
6. Use CSV/SQLite/AI for business understanding
```

## 6. Important design rules

### 6.1 Do not mix parser and business rules

Bad:

```text
XML parser directly decides KEY, VALUE, API, SCREEN
```

Good:

```text
XML parser extracts raw node and edge data
Rule engine decides business meaning
```

### 6.2 Preserve raw data

Always keep raw text, clean text, style, geometry, page, source id, and target id.

### 6.3 Unknown is not an error

Unknown nodes and edges should be exported for review.

```text
unknown_nodes.csv
invalid_edges.csv
```

These files help improve draw.io conventions and rule quality.

### 6.4 Prefer explicit diagram conventions

Recommended node text convention:

```text
KEY:ProductA
VALUE:Red
API:LoginAPI
SCREEN:LoginScreen
REQUEST:LoginRequest
RESPONSE:LoginResponse
TABLE:User
COLUMN:user_id
```

This is more reliable than relying on color, position, or shape.

## 7. First implementation scope

The first parser should support uncompressed draw.io XML, multiple pages when mxGraphModel is directly present, mxCell vertex nodes, mxCell edge edges, basic geometry, style preservation, and CSV export.

The first parser does not need to support compressed diagram payloads, OCR, image text extraction, advanced group semantics, AI classification, or Neo4j export.
