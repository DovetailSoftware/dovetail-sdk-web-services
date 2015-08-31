﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by wsdl, Version=1.1.4322.2032.
// 
namespace FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ClarifyDataAccessSrvSoap", Namespace="http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(ModifierResultProtocol))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(RelationProtocol))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(FieldProtocol))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(ModifierProtocol))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(SortProtocol))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(FilterInListProtocol))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(FilterProtocol))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(QueryProtocol))]
    public class ClarifyDataAccessSrv : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        public AuthenticationHeader AuthenticationHeaderValue;
        
        /// <remarks/>
        public ClarifyDataAccessSrv() {
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthenticationHeaderValue")]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1/Query", RequestNamespace="http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1", ResponseNamespace="http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
        public string Query(QueryProtocol[] generics, bool includeSchema) {
            object[] results = this.Invoke("Query", new object[] {
                        generics,
                        includeSchema});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginQuery(QueryProtocol[] generics, bool includeSchema, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Query", new object[] {
                        generics,
                        includeSchema}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndQuery(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("AuthenticationHeaderValue")]
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1/Update", RequestNamespace="http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1", ResponseNamespace="http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
        public ModifierResultProtocol[] Update(ModifierProtocol[] modificationItems) {
            object[] results = this.Invoke("Update", new object[] {
                        modificationItems});
            return ((ModifierResultProtocol[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdate(ModifierProtocol[] modificationItems, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Update", new object[] {
                        modificationItems}, callback, asyncState);
        }
        
        /// <remarks/>
        public ModifierResultProtocol[] EndUpdate(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((ModifierResultProtocol[])(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("AuthenticationHeader", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    public class AuthenticationHeader : SoapHeader {
        
        /// <remarks/>
        public string SessionID;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("ModifierResultProtocol", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    public class ModifierResultProtocol {
        
        /// <remarks/>
        public string Name;
        
        /// <remarks/>
        public string Action;
        
        /// <remarks/>
        public string Table;
        
        /// <remarks/>
        public int Objid;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("RelationProtocol", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    public class RelationProtocol {
        
        /// <remarks/>
        public string Name;
        
        /// <remarks/>
        public string Reference;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("FieldProtocol", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    public class FieldProtocol {
        
        /// <remarks/>
        public string Name;
        
        /// <remarks/>
        public string Value;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("ModifierProtocol", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(DeleteModifierProtocol))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(UpdateModifierProtocol))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(InsertModifierProtocol))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(ReferenceModifierProtocol))]
    public abstract class ModifierProtocol {
        
        /// <remarks/>
        public string Name;
        
        /// <remarks/>
        public string Table;
        
        /// <remarks/>
        public FieldProtocol[] Fields;
        
        /// <remarks/>
        public FieldProtocol[] UniqueFields;
        
        /// <remarks/>
        public RelationProtocol[] Relations;
        
        /// <remarks/>
        public RelationProtocol[] UniqueRelations;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("DeleteModifierProtocol", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    public class DeleteModifierProtocol : ModifierProtocol {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("UpdateModifierProtocol", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    public class UpdateModifierProtocol : ModifierProtocol {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("InsertModifierProtocol", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    public class InsertModifierProtocol : ModifierProtocol {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("ReferenceModifierProtocol", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    public class ReferenceModifierProtocol : ModifierProtocol {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("SortProtocol", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    public class SortProtocol {
        
        /// <remarks/>
        public string Field;
        
        /// <remarks/>
        public bool IsAscending;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("FilterInListProtocol", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    public class FilterInListProtocol {
        
        /// <remarks/>
        public string Field;
        
        /// <remarks/>
        public bool IsIn;
        
        /// <remarks/>
        public string[] Values;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("FilterProtocol", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    public class FilterProtocol {
        
        /// <remarks/>
        public string Field;
        
        /// <remarks/>
        public string Operation;
        
        /// <remarks/>
        public string Value;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapTypeAttribute("QueryProtocol", "http://www.fchoice.com/schemas/FChoice.WebServices.Clarify.ClarifyDataAccessSrv_v" +
"1")]
    public class QueryProtocol {
        
        /// <remarks/>
        public string ResultTableName;
        
        /// <remarks/>
        public string ObjectName;
        
        /// <remarks/>
        public string TraverseRelation;
        
        /// <remarks/>
        public string[] DataFields;
        
        /// <remarks/>
        public FilterProtocol[] Filters;
        
        /// <remarks/>
        public FilterInListProtocol[] FiltersInList;
        
        /// <remarks/>
        public SortProtocol[] Sorts;
        
        /// <remarks/>
        public QueryProtocol[] ChildGenerics;
    }
}
