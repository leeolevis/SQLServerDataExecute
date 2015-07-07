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
    /// Controller class for DataConfig
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DataConfigController
    {
        // Preload our schema..
        DataConfig thisSchemaLoad = new DataConfig();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public DataConfigCollection FetchAll()
        {
            DataConfigCollection coll = new DataConfigCollection();
            Query qry = new Query(DataConfig.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DataConfigCollection FetchByID(object Id)
        {
            DataConfigCollection coll = new DataConfigCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DataConfigCollection FetchByQuery(Query qry)
        {
            DataConfigCollection coll = new DataConfigCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (DataConfig.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (DataConfig.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string DbService,string DbPort,string DbName,string DbUser,string DbPwd,long OrderOn,DateTime? TaskOn,DateTime? CreateOn,DateTime? ModifiedOn)
	    {
		    DataConfig item = new DataConfig();
		    
            item.DbService = DbService;
            
            item.DbPort = DbPort;
            
            item.DbName = DbName;
            
            item.DbUser = DbUser;
            
            item.DbPwd = DbPwd;
            
            item.OrderOn = OrderOn;
            
            item.TaskOn = TaskOn;
            
            item.CreateOn = CreateOn;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(long Id,string DbService,string DbPort,string DbName,string DbUser,string DbPwd,long OrderOn,DateTime? TaskOn,DateTime? CreateOn,DateTime? ModifiedOn)
	    {
		    DataConfig item = new DataConfig();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.DbService = DbService;
				
			item.DbPort = DbPort;
				
			item.DbName = DbName;
				
			item.DbUser = DbUser;
				
			item.DbPwd = DbPwd;
				
			item.OrderOn = OrderOn;
				
			item.TaskOn = TaskOn;
				
			item.CreateOn = CreateOn;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
