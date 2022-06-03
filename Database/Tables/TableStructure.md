# Table Structure

## All Tables

All Tables have their data plus:

| Col | Type | Default |
| --- | --- | --- |
| CreatedBy | int | NULL |
| CreatedAt | datetime2 | NULL |
| ModifiedBy | int | NULL |
| ModifiedAt | datetime2 | NULL |
| RowVersion | timestamp |  NOT NULL |

## History Tables

| Col | Type | Default | Link (if any) |
| --- | --- | --- | --- |
| HistoryId | int IDENTITY(1,1) | NOT NULL |
| HistoryStatusId | int | NOT NULL | [dbo].[HistoryStatuses]
| ... dbo table data ... |
| CreatedBy | int | NULL |
| CreatedAt | datetime2 | NULL |
| ModifiedBy | int | NULL |
| ModifiedAt | datetime2 | NULL |
| RowVersion | timestamp | NOT NULL |

## Sql Snippets

Created and Modified Schema:

```sql
    CreatedBy int NULL,
    CreatedAt datetime2 NULL DEFAULT sysdatetime(),
    ModifiedBy int NULL,
    ModifiedAt datetime2 NULL,
    RowVersion timestamp NOT NULL
```

History Schema:

```sql
    HistoryId int IDENTITY(1,1) NOT NULL,
    HistoryStatusId int NOT NULL
```
