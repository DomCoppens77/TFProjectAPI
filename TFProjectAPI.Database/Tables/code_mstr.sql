CREATE TABLE [dbo].[code_mstr]
(
	[code_fldname] NVARCHAR(20) NOT NULL,
	[code_value] NVARCHAR(40) NOT NULL,
	[code_desc]  NVARCHAR(100), 
    CONSTRAINT [PK_code_mstr] PRIMARY KEY ([code_fldname], [code_value]),
)
