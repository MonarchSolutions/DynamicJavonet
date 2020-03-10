using System.Dynamic;
using JavonetBridge.Api;

namespace DynamicJavonet
{
    public class DJType : DynamicObject
    {
        public JType JType { get; set; }

        public DJType(JType type)
        {
            JType = type;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = JType.Get<object>(binder.Name).ToDJ();
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            JType.Set(binder.Name, value.AsParameter());
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = JType.Invoke<object>(binder.Name, args.AsParameters()).ToDJ();
            return true;
        }
    }
}