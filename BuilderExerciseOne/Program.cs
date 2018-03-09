using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderExerciseOne
{
    public class Code
    {
        public string fieldName;
        public string fieldType;

    }
    
    public class CodeBuilder
    {
        
        private List<Code> elementList = new List<Code>();
        private string className;
        
        
        public CodeBuilder(string className)
        {
            this.className = className;
        }

        public CodeBuilder AddField(string fieldname, string fieldType)
        {
            var code = new Code();
            code.fieldName = fieldname;
            code.fieldType = fieldType;
            
            elementList.Add(code);
            
            return this;
        }

        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            outputString.Append($"public class {className}\n{{\n");
            foreach (var elementCode in elementList)
            {
                outputString.Append($"  public {elementCode.fieldType} {elementCode.fieldName};\n");
            }

            outputString.Append($"}}");
            return outputString.ToString();
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