### Chapter 1
1. The core features of the CLR (such as memory
management, assembly loading, security, exception handling, and thread synchronization) are available
to any and all programming languages that target it
2. You can develop your code in any programming language you
desire as long as the compiler you use to compile your code targets the CLR. 
3.  Different programming languages allow you to develop using different syntax. Don’t
underestimate the value of this choice. 
4.  I’m aware of compilers for Ada, APL,
Caml, COBOL, Eiffel, Forth, Fortran, Haskell, Lexico, LISP, LOGO, Lua, Mercury, ML, Mondrian, Oberon,
Pascal, Perl, PHP, Prolog, RPG, Scheme, Smalltalk, and Tcl/Tk. 
5. By the way, managed assemblies always take advantage of Data Execution
Prevention (DEP) and Address Space Layout Randomization (ASLR) in Windows; these two features
improve the security of your whole system
6. Source codes are compiled into managed module. Managed module consists of PE32/PE32+ header,CLR Header(Version of the CLR required, flags, MedthodDef metadata token of the managed module's entry point method - main method, location/size of the module's metdata, resource, strong name,), MetaData (Defined types and referred types), IL code(At runtime, the CLR runtime compiles the IL into native CPU instructions).
7.  Metadata is a superset of
older technologies such as COM’s Type Libraries and Interface Definition Language (IDL) files.The
important thing to note is that CLR metadata is far more complete. And, unlike Type Libraries and IDL,
metadata is always associated with the file that contains the IL code. In fact, the metadata is always
embedded in the same EXE/DLL as the code, making it impossible to separate the two.Because the
compiler produces the metadata and the code at the same time and binds them into the resulting
managed module, the metadata and the IL code it describes are never out of sync with one another.
8. Usage of metadata: 1. Manage all reference 2. Code insight 3. CLR code verification - Type-Safe 4. Serialize and deserialization 5. GC tracks the lifetime of objects
9. Managed code includes - managed code (IL) and managed data (Garbage-Collected data types).
10. Assembly:  First, an assembly is a logical grouping of one or more
modules or resource files. Second, an assembly is the smallest unit of reuse, security, and versioning.
Depending on the choices you make with your compilers or tools, you can produce a single-file or a
multifile assembly. In the CLR world, an assembly is what we would call a component. 
11. To tell the exact version .Net Framework installed, you can check the following directory:
    - %SystemRoot%\Microsoft.NET\Framework
    -  %SystemRoot%\Microsoft.NET\Framework64
    or use the command-line utility(included in .Net Framework SDK) called CLRVer.exe to show all of the CLR
12 Use Environment.Is64BitOperatingSystem property to determine if it is running on a 64-bit version of Windows.
   Environment.Is64BitProcess property to determine if it is running in a 64bit address space.   

13 Assembly contains both metadata and IL.keep in mind that any high-level language will most likely expose only a subset of the facilities offered by the CLR.However, the IL assembly language allows a developer to access all of the CLR'S facilities.       
14. To execute a method, its IL must first be converted to native CPU instructions. This is the job of the CLR's JIT(just-intime) compiler. The JIT compiler stores the native CPU instructions in dynamic memory. This means that the compiled code is discarded when the application terminates.So if you run the application again in the future or if you run two instances of the application simultaneously(tow processes), the JIT compiler will have to compile the IL to native instructions again. Depending on the application, this can increase consumption significantly compared to a native application whose read-only code pages can be shared by all instances of the running application.
15. The biggest benefit of IL isn't that it abstracts away the underling CPU. The biggest benefit IL provides is application robustness and security. While compiling IL into native CPU instructions, the CLR performs a process called verification. If you specify Debug JIT will produce a Program Database(PDB) file. The PDB file helps the debugger find local variables and map the IL instructions to source code.  
16. In Windows, each process has its own virtual address space. Separate address spaces are necessary because you can't trust an application's codes. By placing each Windows process in a separate address space, you gain robustness and stability; one process can't adversely affect another process.  
17. By verifying the managed code, however, you know that the code doesn't improperly access memory and can't adversely affect anther application's code.By default, every managed EXE file will
run in its own separate address space that has just one AppDomain. However, a process hosting the
CLR (such as Internet Information Services [IIS] or Microsoft SQL Server) can decide to run AppDomains
in a single OS process.  
18. In addition, the C# compiler requires you to compile the source code by using the /unsafe compiler switch.
When the JIT compiler attempts to compile an unsafe method, it checks to see if the assembly
containing the method has been granted the System.Security.Permissions.Security
Permission with the System.Security.Permissions.SecurityPermissionFlag’s
SkipVerification flag set. If this flag is set, the JIT compiler will compile the unsafe code and allow
it to execute. The CLR is trusting this code and is hoping the direct address and byte manipulations do
not cause any harm. If the flag is not set, the JIT compiler throws either a
System.InvalidProgramException or a System.Security.VerificationException,
preventing the method from executing. In fact, the whole application will probably terminate at this
point, but at least no harm can be done.  
19. The NGen.exe tool that ships with the .NET Framework can be used to compile IL code to native code
when an application is installed on a user’s machine.It targets for two aims: Improving an application's startup time, Reducing an application's working set.  
20. Interoperability with Unmanaged Code:  
    - Managed code can call an unmanaged function in a DLL, using P/Invoke(declare signature in managed code; add attributes if needed onto complex members)
    - Managed code can use COM written in unmanaged code(Using Type library from these Components, an managed Assembly can be created to describe the component **TlbImp.exe**)
    - Unmanaged code can use Components written in managed code (**Tlbexp.exe and RegAsm.exe**)   

### Chapter 2 
1. A managed PE file has four main parts: the PE32(+) header, the CLR header, the metadata, and the IL.  
   - The PE32(+) header is the standard information what Windows expects.
   - The CLR header is a smalll block of information that is specific to modules that require the CLR (managed modules). The header includes the major and minor version number of the CLR that the module was built for: some flags, a MethodDef token indicating the module's entry point method if this module is a CUI, GUI or Windows Store executable, and an optional strong-name digital signature. Finally, the header contains the size and offsets of certain metadata tables contained within the module.** CLR header detailed format saw in IMAGE_COR20_HEADER in CorHdr.h header file **.  
   - The metadata is a block of binary data that consists of several tables, including definition tables, reference tables, and manifest tables.
2. An assembly is a collection of one or more files containing type definitions and resource files. The CLR operates on assemblies; that is, the CLR always loads the file that contains the manifest metadata tables first and then uses the manifest to get the names of the other files that are in the assembly.
3. We can use ILDasm.exe to view internal detailed information.  
4. You configure an application to download assembly files by specifying a ** CodeBase ** element identifies a URL pointing to where all of an assembly's files can be found. When attempting to load an assembly's file, the CLR obtains the ** CodeBase ** element's URL and checks the machine's download cache to see if the file is present. If it is, the file is loaded. If the file isn't in the cache, the CLR downloads the file into the cache from the location the URL points to. If the file can't be found, the CLR throws a FileNotFoundException exception at runtime.  
5. The assembly file that contains the manifest also has an AssemblyRef table in it. This table contains an entry for all of the assemblies referenced by all of the assembly's files.
6. An application can control
its directory and its subdirectories but has no control over other directories.We can put some files in subdirecotr, and configure them properly. And we can add a block in the application configuration file(The value of privatePath can be multiple semicolon-delimited paths):
```<configuration>
 <runtime>
 <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
 <probing privatePath="AuxFiles" />
 </assemblyBinding>
 </runtime>
</configuration> 
```  
7. CLR would atuomatically scan for a subdirectory whose name matches the name of the assembly being searched for.

### Chapter 3

1. A full qualified assembly name consists of four parts: name, version, culture, key.  
2. Use the following commands to generate public/private key :  
  ```
  # Create a public/private key pair
  ```  
  ```
  SN -k MyCompany.snk  
  ```  
  ```
  # view public key
  ```  
  ```
  SN -p MyCompany.snk MyCompany.PublicKey sha256
  ```
  ```
  SN -tp MyCompany.PublicKey
  ```
  The SN utility doesn't offer any way for you to display the private key.
  ```
  # Embed the private key into the project
  ```
  ```
  csc /keyfile:MyCompany.snk program.cs 
  ```
3. By the way, the
AssemblyDef entry always stores the full public key, not the public key token. The full public key is
necessary to ensure that the file hasn’t been tampered with.
4. A strongly named assembly consists of four attributes that uniquely identify the assembly: a file name(without an extension), a version number, a culture identity, and a public key. Since public keys are very large numbers, we frequently use a small hash value derived from a public key.
5. If an assembly is to be accessed by multiple applications, the assembly must be placed into a well-known directory, and the CLR must know to look in this directory automatically when a reference to the assembly is detected. This well-known location is called the global assembly cache (GAC). We can find the directory by:
```
%SystemRoot%Microsoft.NET\Assembly
```
6. The GAC directory is structured, containing many subdirectories, and an algorithm is used to generate the names of these sub-directories. We should only install strongly named assembly using the tool GACUtil.exe.
7. Signing an assembly with a private key and embedding the signature and public key within an assembly allows the CLR to verify that the assembly has not been modified or corrupted.
8. Only check if assembly is tampered with in GAC when intalling, check every time the assembly is loaded when the assembly is not in GAC.
9. Use the following steps to delay sign and sign at final:
   ```
   CSC /keyfile: MyCompany.PublicKey /delaysign MyAssembly.cs
   ``` 
   ```
   Disable file integrity check by: 
   ```  
   ```
   SN.exe -Vr MyAssembly.dll
   ```
   ```
   SN.exe -Ra MyAssembly.dll MyCompany.PrivateKey
   ```
   ```
   SN.exe -Vu MyAssembly.dll
   ```

### Chapter 4
1. All types except for System.Object is inherited from System.Object by default.
2. There are four public method in System.Object.
  - ToString()
  - GetHashCode
  - Equals
  - GetType()
3. There are two overhead memebers, one is Type Object Pointer, the other is Sync Block Index on heap.
4. Stacks build from High adress to Low address. They are used for passing arguments and storing local variables for methods. When calling another method, first pushing arguments one by one to stack, then put the return address then. This can make sure that when method is executed, the pointer can return to source method.
5. After referred Assemblies are loaded, create types used on the heap.
### Chapter 5
1. By default, overflow checking is turned off. It makes the code runs faster. One way to get the C# compiler to control overflows is to use the /checked+ compiler switch.  Programmers can control overflow checking in checking in specific regions of their code.
2. The variable representing the instance doesn't contain a pointer to an instance; the variable  contains the fields of the instance itself. Value type instances don't come under the control of the garbage collector,
Integer, Boolean, Decimal, Timespan, Enumeration
3. Even though you can't choose a base type when defining your own value type, a value type can implement one or more interfaces if you choose. In addition, all value types are sealed, which prevents a value type from being used as a base type for any other reference type or value type.

SomeVal v1 = new SomeVal(). It would zero all of the fields in the value type instance.

4. When a type offers no members that alter its fields, we say that the type is immutable. In fact, it is recommended that many value types mark all their fields as readonly.

5. The size of instances of your type is also a condition to take into account because by default, arguments are passed by value, which causes the fields in the value type instances to be copied, hurting performance.

6. It is obvious that the C# compiler team believes that structures are commonly used when inter-operating with unmanaged code, and for this to work, the fields must stay in the order defined by the programmer.  However, if you are creating a value type that has nothing to do with interoperability with unmanaged code, you could override the C# compiler's default.  Explicit layout is typically used to simulate what would be a union in unmanaged C/C++ because you can have multiple fields starting at the same offset in memory.

7.It's possible to convert a value type to a reference type by using a mechanism called boxing. p129

8. One of the biggest improvements is that the generic collection classes allow you to work with collections of value types without requiring that items in the collection be boxed/unboxed.

9. This in itself greatly improves performance because fewer objects will be created on the managed heap thereby reducing the number of garbage collections required by your application.

10 Furthermore, you will get compile-time type safety, and your source code will be cleaner due to fewer casts. 

### Chapter 6 Type and Memmber Basics

1. Basically, when you add a key/value pair to a collection, a hash code for the key object is obtained
first. This hash code indicates which “bucket” the key/value pair should be stored in. When the
collection needs to look up a key, it gets the hash code for the specified key object. This code identifies
the “bucket” that is now searched sequentially, looking for a stored key object that is equal to the
specified key object. Using this algorithm of storing and looking up keys means that if you change a
key object that is in a collection, the collection will no longer be able to find the object. If you intend to
change a key object in a hash table, you should remove the original key/value pair, modify the key
object, and then add the new key/value pair back into the hash table.
2. A static event is a mechanism that allows a type to send a notification to one or more
static or instance methods. An instance (nonstatic) event is a mechanism that allows an object
to send a notification to one or more static or instance methods. Events are usually raised in
response to a state change occurring in the type or object offering the event. An event consists
of two methods that allow static or instance methods to register and unregister interest in the
event. In addition to the two methods, events typically use a delegate field to maintain the set
of registered methods 
3. If you do not explicitly specify either of these when you define a type, the C# compiler sets the type’s
visibility to  internal.
4. The CLR and C# support this via friend assemblies. This friend assembly
feature is also useful when you want to have one assembly containing code that performs unit tests against the internal types within another assembly. When an assembly is built, it can indicate other assemblies it considers “friends” by using the InternalsVisibleTo attribute defined in the  System.Runtime.CompilerServices namespace.