using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        [FaultContract(typeof(string))]
        AuthorResponse GetAuthorInfo(AuthorRequest Request);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfServiceLibrary.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class Author//opt-in
    {
        [DataMember]
        public string FirstName;

        public string LastName;

        [DataMember]
        public DateTime StartDate;

        [DataMember]
        public string ArticleName;
    }
    [Serializable]
    public class Author1//opt-out
    {
        public string FirstName;

        public string LastName;

        public DateTime StartDate;

        [NonSerialized]
        public string ArticleName;
    }

    [MessageContract(IsWrapped = false)]
    public class AuthorResponse
    {
        [MessageBodyMember]
        public Author AuthorInfo;
    }

    [MessageContract(IsWrapped = false)]
    public class AuthorRequest
    {
        [MessageHeader(Name = "AuthorIdentity")]
        public string AuthorId;
    }
}
