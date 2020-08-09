Расширеные возможности программы-рефлектора из предыдущего урока:
1. Добавлена возможность выбирать, какие именно члены типа должны быть показаны
пользователю. Возможность выбирать сразу несколько членов типа.
2. Добавлена возможность вывода информации об атрибутах для типов и всех членов типа,
которые могут быть декорированы атрибутами.

Results:
------------------------------------------------------------------------------------------------------------------------------------------------------
                                                  THE ASSEMBLY WAS LOADED SUCCESSFULLY!

namespace Additional_Task
{
     [System.AttributeUsageAttribute]
     (class/static class/delegate/event) AccessLevelAttribute
     {
          METHODS:
                                          public Void Access(Human human);

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          public virtual Int32 GetHashCode();

                                          public virtual Object get_TypeId();

                                          public virtual Boolean Match(Object obj);

                                          public virtual Boolean IsDefaultAttribute();

                                          private virtual Void System.Runtime.InteropServices._Attribute.GetTypeInfoCount(UInt32& pcTInfo);

                                          private virtual Void System.Runtime.InteropServices._Attribute.GetTypeInfo(UInt32 iTInfo, UInt32 lcid, IntPtr ppTInfo);

                                          private virtual Void System.Runtime.InteropServices._Attribute.GetIDsOfNames(Guid& riid, IntPtr rgszNames, UInt32 cNames, UInt32 lcid, IntPtr rgDispId);

                                          private virtual Void System.Runtime.InteropServices._Attribute.Invoke(UInt32 dispIdMember, Guid& riid, UInt32 lcid, Int16 wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          FIELDS:
                                          private Human human;

                                          private DateTime date;

                                          private StreamWriter writer;

                                          private AccessLevelControl accessLevel;

          PROPERTIES:
                                          Object TypeId;

          CONSTRUCTORS:
                                          public .ctor(AccessLevelControl accessLevelControl);

     }

     struct enum AccessLevelControl
     {
          METHODS:
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object GetValue();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

                                          [System.ObsoleteAttribute]
                                          public virtual String ToString(String format, IFormatProvider provider);

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 CompareTo(Object target);

                                          [System.ObsoleteAttribute]
                                          public virtual String ToString(IFormatProvider provider);

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Boolean HasFlag(Enum flag);

                                          public virtual TypeCode GetTypeCode();

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Boolean System.IConvertible.ToBoolean(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Char System.IConvertible.ToChar(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual SByte System.IConvertible.ToSByte(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Byte System.IConvertible.ToByte(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Int16 System.IConvertible.ToInt16(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual UInt16 System.IConvertible.ToUInt16(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Int32 System.IConvertible.ToInt32(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual UInt32 System.IConvertible.ToUInt32(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Int64 System.IConvertible.ToInt64(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual UInt64 System.IConvertible.ToUInt64(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Single System.IConvertible.ToSingle(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Double System.IConvertible.ToDouble(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Decimal System.IConvertible.ToDecimal(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual DateTime System.IConvertible.ToDateTime(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Object System.IConvertible.ToType(Type type, IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public String ToString(String format);

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

          FIELDS:
                                          public Int32 value__;

                                          public static AccessLevelControl FullControlforDirector;

                                          public static AccessLevelControl MiddleControlforManager;

                                          public static AccessLevelControl LowControlforProgrammer;

                                          public static AccessLevelControl AccessIsDenied;

     }

     [Additional_Task.AccessLevelAttribute]
     (class/static class/delegate/event) Director
     {
          METHODS:
                                          public Void OpenToBaseBankDate(Human human);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          FIELDS:
                                          public String name;

                                          public String lastName;

          CONSTRUCTORS:
                                          public .ctor(String name, String lastName);

     }

     abstract class Human
     {
          METHODS:
                                          public Void OpenToBaseBankDate(Human human);

                                          private static Void InvokeAttribute(Human human);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          FIELDS:
                                          private OpenFileDialog openFileDialog;

                                          private Form TextBox;

                                          public String name;

                                          public String lastName;

          CONSTRUCTORS:
                                          .ctor(String name, String lastName);

     }

     (class/static class/delegate/event) Manager
     {
          METHODS:
                                          public Void OpenToBaseBankDate(Human human);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          FIELDS:
                                          public String name;

                                          public String lastName;

          CONSTRUCTORS:
                                          public .ctor(String name, String lastName);

     }

     (class/static class/delegate/event) Other
     {
          METHODS:
                                          public Void OpenToBaseBankDate(Human human);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          FIELDS:
                                          public String name;

                                          public String lastName;

          CONSTRUCTORS:
                                          public .ctor(String name, String lastName);

     }

     (class/static class/delegate/event) Program
     {
          METHODS:
                                          [System.STAThreadAttribute]
                                          private static Void Main(String[] args);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          CONSTRUCTORS:
                                          public .ctor();

     }

     (class/static class/delegate/event) Programmer
     {
          METHODS:
                                          public Void OpenToBaseBankDate(Human human);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          FIELDS:
                                          public String name;

                                          public String lastName;

          CONSTRUCTORS:
                                          public .ctor(String name, String lastName);

     }
}
