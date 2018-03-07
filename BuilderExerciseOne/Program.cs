using System;
using System.Text;

namespace BuilderExerciseOne
{
    public class CodeBuilder
    {
        StringBuilder codeString = new StringBuilder();
        
        public CodeBuilder(string className){
            codeString.Append($"public class {className}\\n{{\\n");
            
        }
        
        public StringBuilder AddField(string fieldName, string stringType){
            codeString.Append($"  public {stringType} {fieldName};\n");
            return codeString;

        }

//        public override string WriteLine()
//        {
//            return codeString.Append($"}}").ToString();
//        }
    }
    
    public class Program
    {
        static void Main(){
            var cb = new CodeBuilder("Person").AddField("Name","string");//.AddField("Age","int");
            Console.WriteLine(cb);
        }
    }
}