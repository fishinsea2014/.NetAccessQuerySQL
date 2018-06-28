# .NetAccessQuerySQL
+ Main contents:
  + Basic structure construction of the project
  + Basic query encapsulation
  + Mapping mapping processing
  + Add and delete data
  + Feature universal validation
  + Generic cache
+ Task Process
  1. Create a database in SQL server, and then execute the database script in appendix. Create two tables, Company and User.
  2. Establish the base class BaseModel for mapping database table, including Id attributes etc. Create two subclasses, the Model: Company and User, according to the table structure.
  3. Provides two generic database access methods with BaseModel constraints
	- One is to query a single entity with an id (only one parameter)
	- One is to query the entire data list query out of the data table (no parameters)
	- Using DataReader to access the database, the return is creating entity objects/collections through reflection. 
  4. Supposing that the table/field name of the database is not consistent with the entity in the program, try to mapping corresponding items by attribute
  5. Use generic to implement accessing database with entity instance, e.g. insert, update, delete,find
  6. Abstract the data access layer by the way of simple factory + configuration file + reflection, for the data access layer to use.
  7. Validating data in entity instances, e.g. format of mobile, email, length of user name. Sometimes there are multiple validation to a field or property.
  8. Use delegate to encapsulate SQL server connection and query actions.
   
  
  Appendix: Sql script:
	
	CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreatorId] [int] NOT NULL,
	[LastModifierId] [int] NULL,
	[LastModifyTime] [datetime] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
																																						
																																						
INSERT INTO [dbo].[Company]
           ([Name]
           ,[CreateTime]
           ,[CreatorId]
           ,[LastModifierId]
           ,[LastModifyTime])
     VALUES
           ('The warehouse'
           ,'2015-12-10'
           ,1
           ,1
           ,'2015-12-10')
																																						
																																						
INSERT INTO [dbo].[Company]
           ([Name]
           ,[CreateTime]
           ,[CreatorId]
           ,[LastModifierId]
           ,[LastModifyTime])
     VALUES
           ('New World'
           ,'2015-12-10'
           ,1
           ,1
           ,'2015-12-10')
																																						
																																						
INSERT INTO [dbo].[Company]
           ([Name]
           ,[CreateTime]
           ,[CreatorId]
           ,[LastModifierId]
           ,[LastModifyTime])
     VALUES
           ('Toyota'
           ,'2015-12-10'
           ,1
           ,1
           ,'2015-12-10')
																																						

																																						
																																						
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Account] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Email] [varchar](200) NULL,
	[Mobile] [varchar](30) NULL,
	[CompanyId] [int] NULL,
	[CompanyName] [nvarchar](500) NULL,
	[State] [int] NOT NULL,
	[UserType] [int] NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreatorId] [int] NOT NULL,
	[LastModifierId] [int] NULL,
	[LastModifyTime] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
																																						
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserState  0Normal 1Freezed 2Deleted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'State'
GO
																																						
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserType  1NormalUser 2Admin 4SuperAdmin' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UserType'
GO
																
					
																																						
INSERT INTO [dbo].[User]
           ([Name]
           ,[Account]
           ,[Password]
           ,[Email]
           ,[Mobile]
           ,[CompanyId]
           ,[CompanyName]
           ,[State]
           ,[UserType]
           ,[LastLoginTime]
           ,[CreateTime]
           ,[CreatorId]
           ,[LastModifierId]
           ,[LastModifyTime])
     VALUES
           ('Jason'
           ,'admin'
           ,'e10adc3949ba59abbe56e057f20f883e'
           ,'12'
           ,'133'	
           ,'1'	
           ,'Toyota'	
           ,0
           ,2
           ,'2015-12-12'	
           ,'2015-12-12'
           ,1
           ,1
           ,'2015-12-12')
GO
