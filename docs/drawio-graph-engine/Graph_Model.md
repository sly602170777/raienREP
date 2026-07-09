# Graph Model: Node and Edge

## 1. Purpose

This document defines the common graph data model used by the Draw.io Graph Engine.

The model is intentionally generic. It should work for different types of draw.io diagrams, including:

```text
key-value diagrams
API diagrams
screen flow diagrams
request/response diagrams
database ER-like diagrams
business workflow diagrams
mixed diagrams
```

The parser should produce a generic graph first. Business meaning should be added later by the rule engine.

## 2. Core idea

A graph is made of two basic parts:

```text
Node = object / thing / concept
Edge = relationship between two nodes
```

For draw.io:

```text
draw.io shape / text box / image / database icon -> Node
draw.io connector / arrow / line                 -> Edge
```

## 3. Node model

A Node represents an object in the diagram.

Examples:

```text
ProductA
Red
LoginScreen
LoginAPI
LoginResponse
userId
UserTable
OrderTable
image_001
```

### 3.1 Required node fields

| Field | Description |
|---|---|
| node_id | Original draw.io mxCell id |
| page | Diagram page name |
| raw_text | Original value text from XML |
| clean_text | Cleaned human-readable text |
| node_type | Business type, initially UNKNOWN |
| x | X coordinate if available |
| y | Y coordinate if available |
| width | Width if available |
| height | Height if available |
| style | Original draw.io style string |
| parent_id | Parent/group id if available |

### 3.2 Node CSV format

Recommended `nodes.csv` columns:

```csv
node_id,page,raw_text,clean_text,node_type,x,y,width,height,style,parent_id
```

Example:

```csv
node_id,page,raw_text,clean_text,node_type,x,y,width,height,style,parent_id
n1,Page_1,KEY:ProductA,ProductA,KEY,100,80,120,40,rounded=1;,1
n2,Page_1,VALUE:Red,Red,VALUE,300,80,100,40,rounded=1;,1
```

### 3.3 Node type

The parser should initially set node type to:

```text
UNKNOWN
```

The rule engine may later convert it to:

```text
KEY
VALUE
API
SCREEN
REQUEST
RESPONSE
TABLE
COLUMN
IMAGE
GROUP
TAG
UNKNOWN
```

Important: `UNKNOWN` should not be treated as an error. It is useful for review and rule improvement.

## 4. Edge model

An Edge represents a relationship between two nodes.

Examples:

```text
ProductA -> Red
LoginScreen -> LoginAPI
LoginAPI -> LoginResponse
UserTable -> user_id
```

### 4.1 Required edge fields

| Field | Description |
|---|---|
| edge_id | Original draw.io mxCell id |
| page | Diagram page name |
| source_id | Source node id |
| target_id | Target node id |
| raw_label | Original label from XML |
| clean_label | Cleaned label |
| relation | Business relation, initially UNKNOWN |
| style | Original draw.io style string |
| parent_id | Parent/group id if available |

### 4.2 Edge CSV format

Recommended `edges.csv` columns:

```csv
edge_id,page,source_id,target_id,raw_label,clean_label,relation,style,parent_id
```

Example:

```csv
edge_id,page,source_id,target_id,raw_label,clean_label,relation,style,parent_id
e1,Page_1,n1,n2,hasColor,hasColor,HAS_COLOR,endArrow=classic;,1
```

### 4.3 Relation type

The parser should initially set relation to:

```text
UNKNOWN
```

The rule engine may later convert it to:

```text
HAS
HAS_COLOR
HAS_SIZE
CALLS
RETURNS
CONTAINS
MAPS_TO
HAS_COLUMN
NEXT
USES
DEPENDS_ON
UNKNOWN
```

## 5. Direction rules

Direction matters.

```text
source_id -> target_id
```

Example:

```text
SCREEN:LoginScreen -> API:LoginAPI
```

means:

```text
LoginScreen CALLS LoginAPI
```

If the source and target are reversed in draw.io, the analyzer may need a reverse-compatibility rule.

Example:

```text
VALUE:Red -> KEY:ProductA
```

may still be normalized to:

```text
ProductA HAS Red
```

But this should be handled by the analyzer, not by the raw parser.

## 6. Raw graph vs business graph

### 6.1 Raw graph

Generated directly from XML.

```text
raw nodes
raw edges
node_type = UNKNOWN
relation = UNKNOWN
```

### 6.2 Business graph

Generated after applying rules.

```text
node_type = KEY / VALUE / API / SCREEN / ...
relation = HAS / CALLS / RETURNS / ...
```

This separation is important because the same draw.io XML structure can represent different business domains.

## 7. Quality-check outputs

The graph model should support quality-control exports.

Recommended files:

```text
unknown_nodes.csv
invalid_edges.csv
duplicate_edges.csv
isolated_nodes.csv
```

### 7.1 unknown_nodes.csv

Nodes that could not be classified by the rule engine.

Use this file to improve rules or diagram conventions.

### 7.2 invalid_edges.csv

Edges whose `source_id` or `target_id` does not exist in `nodes.csv`.

These may indicate broken connectors or unsupported draw.io structures.

### 7.3 duplicate_edges.csv

Duplicate relationships with the same source, target, and relation.

### 7.4 isolated_nodes.csv

Nodes that are not connected to any edge.

These may be notes, unused items, or missing connectors.

## 8. Business output examples

### 8.1 Key-value relation output

Input graph:

```text
KEY:ProductA -> VALUE:Red
KEY:ProductA -> VALUE:L
KEY:ProductB -> VALUE:Red
```

Final `relations.csv`:

```csv
page,key,value,relation,key_node_id,value_node_id
Page_1,ProductA,Red,HAS,n1,n2
Page_1,ProductA,L,HAS,n1,n3
Page_1,ProductB,Red,HAS,n4,n2
```

### 8.2 Screen API output

Input graph:

```text
SCREEN:LoginScreen -> API:LoginAPI
API:LoginAPI -> RESPONSE:LoginResponse
```

Possible `screen_api.csv`:

```csv
page,screen,api,relation,screen_node_id,api_node_id
Page_1,LoginScreen,LoginAPI,CALLS,n1,n2
```

## 9. Recommended diagram conventions

For better extraction precision, diagrams should use explicit prefixes:

```text
KEY:ProductA
VALUE:Red
API:LoginAPI
SCREEN:LoginScreen
REQUEST:LoginRequest
RESPONSE:LoginResponse
TABLE:User
COLUMN:user_id
IMAGE:image_001
```

Explicit prefixes are more reliable than color, position, or shape.

Colors and shapes may still be used as secondary rules.

## 10. Design principles

1. Preserve raw data.
2. Keep parser generic.
3. Keep business rules configurable.
4. Keep unknown data visible.
5. Prefer long-table CSV outputs for many-to-many relationships.
6. Do not rely on OCR unless the text is truly embedded inside images.
7. Treat draw.io as a visual editor, not the final database.

## 11. Future extensions

Possible future model additions:

```text
node attributes
edge attributes
page metadata
group hierarchy
image OCR text
confidence score
source file path
created_at / updated_at
AI classification reason
```

These should be added without breaking the basic node/edge model.
