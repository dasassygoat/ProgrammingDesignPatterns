using System;
using System.Text;

namespace BuilderExerciseOne
{
    public class CodeBuilder
    {
        private StringBuilder codeString = new StringBuilder();
        
        public CodeBuilder(string className){
            codeString.Append($"public class {className}\n{{\n");
            
        }
        
        public CodeBuilder AddField(string fieldName, string stringType){
            codeString.Append($"  public {stringType} {fieldName};\n");
            return this;

        }

    }
    
    public class Program
    {
        static void Main(){
            CodeBuilder cb = new CodeBuilder("Person").AddField("Name","string").AddField("Age","int");
            Console.WriteLine(cb);
        }
    }
}