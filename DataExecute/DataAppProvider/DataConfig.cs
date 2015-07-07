using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
namespace SubSonic.Generated
{
	/// <summary>
	/// Strongly-typed collection for the DataConfig class.
	/// </summary>
    [Serializable]
	public partial class DataConfigCollection : ActiveList<DataConfig, DataConfigCollection>
	{	   
		public DataConfigCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DataConfigCollection</returns>
		public DataConfigCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DataConfig o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the DataConfig table.
	/// </summary>
	[Serializable]
	public partial class DataConfig : ActiveRecord<DataConfig>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DataConfig()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DataConfig(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DataConfig(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DataConfig(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("DataConfig", TableType.Table, DataService.GetInstance("DataAppProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"main";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "Id";
				colvarId.DataType = DbType.Int64;
				colvarId.MaxLength = 8;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarDbService = new TableSchema.TableColumn(schema);
				colvarDbService.ColumnName = "dbService";
				colvarDbService.DataType = DbType.String;
				colvarDbService.MaxLength = 50;
				colvarDbService.AutoIncrement = false;
				colvarDbService.IsNullable = true;
				colvarDbService.IsPrimaryKey = false;
				colvarDbService.IsForeignKey = false;
				colvarDbService.IsReadOnly = false;
				colvarDbService.DefaultSetting = @"";
				colvarDbService.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDbService);
				
				TableSchema.TableColumn colvarDbPort = new TableSchema.TableColumn(schema);
				colvarDbPort.ColumnName = "dbPort";
				colvarDbPort.DataType = DbType.String;
				colvarDbPort.MaxLength = 50;
				colvarDbPort.AutoIncrement = false;
				colvarDbPort.IsNullable = true;
				colvarDbPort.IsPrimaryKey = false;
				colvarDbPort.IsForeignKey = false;
				colvarDbPort.IsReadOnly = false;
				colvarDbPort.DefaultSetting = @"";
				colvarDbPort.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDbPort);
				
				TableSchema.TableColumn colvarDbName = new TableSchema.TableColumn(schema);
				colvarDbName.ColumnName = "dbName";
				colvarDbName.DataType = DbType.String;
				colvarDbName.MaxLength = 50;
				colvarDbName.AutoIncrement = false;
				colvarDbName.IsNullable = true;
				colvarDbName.IsPrimaryKey = false;
				colvarDbName.IsForeignKey = false;
				colvarDbName.IsReadOnly = false;
				colvarDbName.DefaultSetting = @"";
				colvarDbName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDbName);
				
				TableSchema.TableColumn colvarDbUser = new TableSchema.TableColumn(schema);
				colvarDbUser.ColumnName = "dbUser";
				colvarDbUser.DataType = DbType.String;
				colvarDbUser.MaxLength = 50;
				colvarDbUser.AutoIncrement = false;
				colvarDbUser.IsNullable = true;
				colvarDbUser.IsPrimaryKey = false;
				colvarDbUser.IsForeignKey = false;
				colvarDbUser.IsReadOnly = false;
				colvarDbUser.DefaultSetting = @"";
				colvarDbUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDbUser);
				
				TableSchema.TableColumn colvarDbPwd = new TableSchema.TableColumn(schema);
				colvarDbPwd.ColumnName = "dbPwd";
				colvarDbPwd.DataType = DbType.String;
				colvarDbPwd.MaxLength = 50;
				colvarDbPwd.AutoIncrement = false;
				colvarDbPwd.IsNullable = true;
				colvarDbPwd.IsPrimaryKey = false;
				colvarDbPwd.IsForeignKey = false;
				colvarDbPwd.IsReadOnly = false;
				colvarDbPwd.DefaultSetting = @"";
				colvarDbPwd.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDbPwd);
				
				TableSchema.TableColumn colvarOrderOn = new TableSchema.TableColumn(schema);
				colvarOrderOn.ColumnName = "OrderOn";
				colvarOrderOn.DataType = DbType.Int64;
				colvarOrderOn.MaxLength = 8;
				colvarOrderOn.AutoIncrement = false;
				colvarOrderOn.IsNullable = false;
				colvarOrderOn.IsPrimaryKey = false;
				colvarOrderOn.IsForeignKey = false;
				colvarOrderOn.IsReadOnly = false;
				colvarOrderOn.DefaultSetting = @"";
				colvarOrderOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderOn);
				
				TableSchema.TableColumn colvarTaskOn = new TableSchema.TableColumn(schema);
				colvarTaskOn.ColumnName = "TaskOn";
				colvarTaskOn.DataType = DbType.DateTime;
				colvarTaskOn.MaxLength = 48;
				colvarTaskOn.AutoIncrement = false;
				colvarTaskOn.IsNullable = true;
				colvarTaskOn.IsPrimaryKey = false;
				colvarTaskOn.IsForeignKey = false;
				colvarTaskOn.IsReadOnly = false;
				colvarTaskOn.DefaultSetting = @"";
				colvarTaskOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTaskOn);
				
				TableSchema.TableColumn colvarCreateOn = new TableSchema.TableColumn(schema);
				colvarCreateOn.ColumnName = "CreateOn";
				colvarCreateOn.DataType = DbType.DateTime;
				colvarCreateOn.MaxLength = 48;
				colvarCreateOn.AutoIncrement = false;
				colvarCreateOn.IsNullable = true;
				colvarCreateOn.IsPrimaryKey = false;
				colvarCreateOn.IsForeignKey = false;
				colvarCreateOn.IsReadOnly = false;
				colvarCreateOn.DefaultSetting = @"";
				colvarCreateOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreateOn);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 48;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = true;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DataAppProvider"].AddSchema("DataConfig",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public long Id 
		{
			get { return GetColumnValue<long>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("DbService")]
		[Bindable(true)]
		public string DbService 
		{
			get { return GetColumnValue<string>(Columns.DbService); }
			set { SetColumnValue(Columns.DbService, value); }
		}
		  
		[XmlAttribute("DbPort")]
		[Bindable(true)]
		public string DbPort 
		{
			get { return GetColumnValue<string>(Columns.DbPort); }
			set { SetColumnValue(Columns.DbPort, value); }
		}
		  
		[XmlAttribute("DbName")]
		[Bindable(true)]
		public string DbName 
		{
			get { return GetColumnValue<string>(Columns.DbName); }
			set { SetColumnValue(Columns.DbName, value); }
		}
		  
		[XmlAttribute("DbUser")]
		[Bindable(true)]
		public string DbUser 
		{
			get { return GetColumnValue<string>(Columns.DbUser); }
			set { SetColumnValue(Columns.DbUser, value); }
		}
		  
		[XmlAttribute("DbPwd")]
		[Bindable(true)]
		public string DbPwd 
		{
			get { return GetColumnValue<string>(Columns.DbPwd); }
			set { SetColumnValue(Columns.DbPwd, value); }
		}
		  
		[XmlAttribute("OrderOn")]
		[Bindable(true)]
		public long OrderOn 
		{
			get { return GetColumnValue<long>(Columns.OrderOn); }
			set { SetColumnValue(Columns.OrderOn, value); }
		}
		  
		[XmlAttribute("TaskOn")]
		[Bindable(true)]
		public DateTime? TaskOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.TaskOn); }
			set { SetColumnValue(Columns.TaskOn, value); }
		}
		  
		[XmlAttribute("CreateOn")]
		[Bindable(true)]
		public DateTime? CreateOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreateOn); }
			set { SetColumnValue(Columns.CreateOn, value); }
		}
		  
		[XmlAttribute("ModifiedOn")]
		[Bindable(true)]
		public DateTime? ModifiedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDbService,string varDbPort,string varDbName,string varDbUser,string varDbPwd,long varOrderOn,DateTime? varTaskOn,DateTime? varCreateOn,DateTime? varModifiedOn)
		{
			DataConfig item = new DataConfig();
			
			item.DbService = varDbService;
			
			item.DbPort = varDbPort;
			
			item.DbName = varDbName;
			
			item.DbUser = varDbUser;
			
			item.DbPwd = varDbPwd;
			
			item.OrderOn = varOrderOn;
			
			item.TaskOn = varTaskOn;
			
			item.CreateOn = varCreateOn;
			
			item.ModifiedOn = varModifiedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(long varId,string varDbService,string varDbPort,string varDbName,string varDbUser,string varDbPwd,long varOrderOn,DateTime? varTaskOn,DateTime? varCreateOn,DateTime? varModifiedOn)
		{
			DataConfig item = new DataConfig();
			
				item.Id = varId;
			
				item.DbService = varDbService;
			
				item.DbPort = varDbPort;
			
				item.DbName = varDbName;
			
				item.DbUser = varDbUser;
			
				item.DbPwd = varDbPwd;
			
				item.OrderOn = varOrderOn;
			
				item.TaskOn = varTaskOn;
			
				item.CreateOn = varCreateOn;
			
				item.ModifiedOn = varModifiedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DbServiceColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DbPortColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DbNameColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DbUserColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DbPwdColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn OrderOnColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TaskOnColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CreateOnColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string DbService = @"dbService";
			 public static string DbPort = @"dbPort";
			 public static string DbName = @"dbName";
			 public static string DbUser = @"dbUser";
			 public static string DbPwd = @"dbPwd";
			 public static string OrderOn = @"OrderOn";
			 public static string TaskOn = @"TaskOn";
			 public static string CreateOn = @"CreateOn";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
