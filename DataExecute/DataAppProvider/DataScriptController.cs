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
    /// Controller class for DataScript
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DataScriptController
    {
        // Preload our schema..
        DataScript thisSchemaLoad = new DataScript();
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
        public DataScriptCollection FetchAll()
        {
            DataScriptCollection coll = new DataScriptCollection();
            Query qry = new Query(DataScript.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DataScriptCollection FetchByID(object Id)
        {
            DataScriptCollection coll = new DataScriptCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DataScriptCollection FetchByQuery(Query qry)
        {
            DataScriptCollection coll = new DataScriptCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (DataScript.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (DataScript.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string ScriptName,string ScriptPath,string ScriptContent,long DbId,string DbContent,long OrderOn,DateTime? TaskOn,DateTime? CreateOn,DateTime? ModifiedOn)
	    {
		    DataScript item = new DataScript();
		    
            item.ScriptName = ScriptName;
            
            item.ScriptPath = ScriptPath;
            
            item.ScriptContent = ScriptContent;
            
            item.DbId = DbId;
            
            item.DbContent = DbContent;
            
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
	    public void Update(long Id,string ScriptName,string ScriptPath,string ScriptContent,long DbId,string DbContent,long OrderOn,DateTime? TaskOn,DateTime? CreateOn,DateTime? ModifiedOn)
	    {
		    DataScript item = new DataScript();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.ScriptName = ScriptName;
				
			item.ScriptPath = ScriptPath;
				
			item.ScriptContent = ScriptContent;
				
			item.DbId = DbId;
				
			item.DbContent = DbContent;
				
			item.OrderOn = OrderOn;
				
			item.TaskOn = TaskOn;
				
			item.CreateOn = CreateOn;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
