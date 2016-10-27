using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        private const string AuthorId = "db2972";
        public AuthorResponse GetAuthorInfo(AuthorRequest Request)
        {
            if (Request.AuthorId != AuthorId)
            {
                string error = "Invalid author id";
                throw new Exception(error);
            }
            AuthorResponse response = new AuthorResponse();
            response.AuthorInfo = new Author();
            response.AuthorInfo.FirstName = "Ravi";
            response.AuthorInfo.LastName = "Boyina";
            response.AuthorInfo.ArticleName = "WCF Training";
            return response;
        }
    }


}

/*
DataContractSerializer

DataContractSerializer uses the Opt-In approach.This approach serializes properties as well as fields.We can serialize protected and private members also.The DataContractSerializer is faster than XMLSerializer because we don't have full control over serialization. 


XMLSerializer

XMLSerializer uses The Opt-Out approach. This approach serializes properties only and it must be a public. It cannot understand the DataContractSerializer attribute.It will not serialize unless we apply the serializable attribute.

Conclusion

The DataContractSerializer is always able to serialize to XML, but it is for very small and simple XML.It focuses on speed instead of on being comprehensive.And XMLSerializer is used for comprehensive XML schemas.
*/
