using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionTry
{
    public class FunctionData : Data
    {
        private MethodInfo _methodInfo;
        private Data _myresult;

        public override Data ResultType => _myresult;

        public override bool CanContinue => _myresult.CanContinue;

        public override bool CanEnd => true;
        public override string GiveCode(bool isEnd)
        {
            if (isEnd)
            {
                return _methodInfo.Name+"();";
            }
            else
            {
                return _methodInfo.Name + "().";
            }
        }

        public override string Id { get; protected set; }

        public override string Name
        {
            get
            {
                var attrName = GetNameByAttributes(_methodInfo.GetCustomAttributes(true));
                if (attrName != null)
                {
                    return attrName;
                }
                return _methodInfo.Name;
            }
        }

        public FunctionData(MethodInfo methodInfo)
        {
            Id = "Func."+methodInfo.Name + "." + methodInfo.DeclaringType;
            _methodInfo = methodInfo;

            var returnType = _methodInfo.ReturnType;
            if (returnType.IsPrimitive)
            {
                _myresult = new PrimitiveData(returnType);
            }
            else if (returnType.IsClass)
            {
                _myresult = new ClassData(false, returnType);
            }
            else
            {
                _myresult = new NoData();
            }
        }

        public IEnumerable<ParameterData> Parameters
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        
       

        public override IEnumerable<Data> GetContinue()
        {
            return _myresult.GetContinue();
        }

    }
}