using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    [DataContract]
    class SurrogateCafe : IDataContractSurrogate
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public Cacher Cacher { get; set; }

        public SurrogateCafe(string name, string location)
        {
            
        }

        public Type GetDataContractType(Type type)
        {
            throw new NotImplementedException();
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            throw new NotImplementedException();
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            throw new NotImplementedException();
        }

        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }

        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }

        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }

        [OnSerializing]
        public void MethodSample1(StreamingContext context)
        {
            Console.WriteLine("OnSerializing");
        }

        [OnSerialized]
        public void MethodSample2(StreamingContext context)
        {
            Console.WriteLine("OnSerialized");
        }

    }

    internal class Cacher
    {
        public int Number { get; set; }

        internal static Cacher GetCacher()
        {
            return new Cacher();
        }

    }

    public class SurrogateWork
    {
        public static void DoProc()
        {
            var instance = new SurrogateCafe(name:"excel", location:"tsukiji");
            instance.Cacher = Cacher.GetCacher();

            var selializer = new DataContractJsonSerializer(typeof(SurrogateCafe));
            MemoryStream stream = new MemoryStream();
            selializer.WriteObject(stream, instance);
            
            StreamReader reader = new StreamReader(stream);
            Console.WriteLine(reader.ReadToEnd());
            
            
        }
    }
}
