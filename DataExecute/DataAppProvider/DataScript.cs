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
	/// Strongly-typed collection for the DataScript class.
	/// </summary>
    [Serializable]
	public partial class DataScriptCollection : ActiveList<DataScript, DataScriptCollection>
	{	   
		public DataScriptCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DataScriptCollection</returns>
		public DataScriptCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DataScript o = this[i];
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
	/// This is an ActiveRecord class which wraps the DataScript table.
	/// </summary>
	[Serializable]
	public partial class DataScript : ActiveRecord<DataScript>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DataScript()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DataScript(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DataScript(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DataScript(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DataScript", TableType.Table, DataService.GetInstance("DataAppProvider"));
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
				
				TableSchema.TableColumn colvarScriptName = new TableSchema.TableColumn(schema);
				colvarScriptName.ColumnName = "ScriptName";
				colvarScriptName.DataType = DbType.String;
				colvarScriptName.MaxLength = 50;
				colvarScriptName.AutoIncrement = false;
				colvarScriptName.IsNullable = true;
				colvarScriptName.IsPrimaryKey = false;
				colvarScriptName.IsForeignKey = false;
				colvarScriptName.IsReadOnly = false;
				colvarScriptName.DefaultSetting = @"";
				colvarScriptName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarScriptName);
				
				TableSchema.TableColumn colvarScriptPath = new TableSchema.TableColumn(schema);
				colvarScriptPath.ColumnName = "ScriptPath";
				colvarScriptPath.DataType = DbType.String;
				colvarScriptPath.MaxLength = 2147483647;
				colvarScriptPath.AutoIncrement = false;
				colvarScriptPath.IsNullable = true;
				colvarScriptPath.IsPrimaryKey = false;
				colvarScriptPath.IsForeignKey = false;
				colvarScriptPath.IsReadOnly = false;
				colvarScriptPath.DefaultSetting = @"";
				colvarScriptPath.ForeignKeyTableName = "";
				schema.Columns.Add(colvarScriptPath);
				
				TableSchema.TableColumn colvarScriptContent = new TableSchema.TableColumn(schema);
				colvarScriptContent.ColumnName = "ScriptContent";
				colvarScriptContent.DataType = DbType.String;
				colvarScriptContent.MaxLength = 2147483647;
				colvarScriptContent.AutoIncrement = false;
				colvarScriptContent.IsNullable = true;
				colvarScriptContent.IsPrimaryKey = false;
				colvarScriptContent.IsForeignKey = false;
				colvarScriptContent.IsReadOnly = false;
				colvarScriptContent.DefaultSetting = @"";
				colvarScriptContent.ForeignKeyTableName = "";
				schema.Columns.Add(colvarScriptContent);
				
				TableSchema.TableColumn colvarDbId = new TableSchema.TableColumn(schema);
				colvarDbId.ColumnName = "dbId";
				colvarDbId.DataType = DbType.Int64;
				colvarDbId.MaxLength = 8;
				colvarDbId.AutoIncrement = false;
				colvarDbId.IsNullable = false;
				colvarDbId.IsPrimaryKey = false;
				colvarDbId.IsForeignKey = false;
				colvarDbId.IsReadOnly = false;
				colvarDbId.DefaultSetting = @"";
				colvarDbId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDbId);
				
				TableSchema.TableColumn colvarDbContent = new TableSchema.TableColumn(schema);
				colvarDbContent.ColumnName = "dbContent";
				colvarDbContent.DataType = DbType.String;
				colvarDbContent.MaxLength = 2147483647;
				colvarDbContent.AutoIncrement = false;
				colvarDbContent.IsNullable = true;
				colvarDbContent.IsPrimaryKey = false;
				colvarDbContent.IsForeignKey = false;
				colvarDbContent.IsReadOnly = false;
				colvarDbContent.DefaultSetting = @"";
				colvarDbContent.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDbContent);
				
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
				DataService.Providers["DataAppProvider"].AddSchema("DataScript",schema);
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
		  
		[XmlAttribute("ScriptName")]
		[Bindable(true)]
		public string ScriptName 
		{
			get { return GetColumnValue<string>(Columns.ScriptName); }
			set { SetColumnValue(Columns.ScriptName, value); }
		}
		  
		[XmlAttribute("ScriptPath")]
		[Bindable(true)]
		public string ScriptPath 
		{
			get { return GetColumnValue<string>(Columns.ScriptPath); }
			set { SetColumnValue(Columns.ScriptPath, value); }
		}
		  
		[XmlAttribute("ScriptContent")]
		[Bindable(true)]
		public string ScriptContent 
		{
			get { return GetColumnValue<string>(Columns.ScriptContent); }
			set { SetColumnValue(Columns.ScriptContent, value); }
		}
		  
		[XmlAttribute("DbId")]
		[Bindable(true)]
		public long DbId 
		{
			get { return GetColumnValue<long>(Columns.DbId); }
			set { SetColumnValue(Columns.DbId, value); }
		}
		  
		[XmlAttribute("DbContent")]
		[Bindable(true)]
		public string DbContent 
		{
			get { return GetColumnValue<string>(Columns.DbContent); }
			set { SetColumnValue(Columns.DbContent, value); }
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
		public static void Insert(string varScriptName,string varScriptPath,string varScriptContent,long varDbId,string varDbContent,long varOrderOn,DateTime? varTaskOn,DateTime? varCreateOn,DateTime? varModifiedOn)
		{
			DataScript item = new DataScript();
			
			item.ScriptName = varScriptName;
			
			item.ScriptPath = varScriptPath;
			
			item.ScriptContent = varScriptContent;
			
			item.DbId = varDbId;
			
			item.DbContent = varDbContent;
			
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
		public static void Update(long varId,string varScriptName,string varScriptPath,string varScriptContent,long varDbId,string varDbContent,long varOrderOn,DateTime? varTaskOn,DateTime? varCreateOn,DateTime? varModifiedOn)
		{
			DataScript item = new DataScript();
			
				item.Id = varId;
			
				item.ScriptName = varScriptName;
			
				item.ScriptPath = varScriptPath;
			
				item.ScriptContent = varScriptContent;
			
				item.DbId = varDbId;
			
				item.DbContent = varDbContent;
			
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
        
        
        
        public static TableSchema.TableColumn ScriptNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ScriptPathColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ScriptContentColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DbIdColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DbContentColumn
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
			 public static string ScriptName = @"ScriptName";
			 public static string ScriptPath = @"ScriptPath";
			 public static string ScriptContent = @"ScriptContent";
			 public static string DbId = @"dbId";
			 public static string DbContent = @"dbContent";
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
