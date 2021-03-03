<?xml version='1.0' encoding='UTF-8' standalone='yes' ?>
<tagfile doxygen_version="1.9.1" doxygen_gitid="ef9b20ac7f8a8621fcfc299f8bd0b80422390f4b">
  <compound kind="class">
    <name>NanoByte::CodeGeneration::CSharpAttribute</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_c_sharp_attribute.html</filename>
    <member kind="function">
      <type></type>
      <name>CSharpAttribute</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_attribute.html</anchorfile>
      <anchor>ae6eaf4881b823d0b6e62f3070b897f49</anchor>
      <arglist>(CSharpIdentifier identifier)</arglist>
    </member>
    <member kind="function" protection="package">
      <type>AttributeListSyntax</type>
      <name>ToSyntax</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_attribute.html</anchorfile>
      <anchor>a3f787b3bb3e71ab835f939854479bd8a</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="property">
      <type>CSharpIdentifier</type>
      <name>Identifier</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_attribute.html</anchorfile>
      <anchor>ad272a9accb64d6d3ca848d1ffd6ddd10</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>List&lt; object &gt;</type>
      <name>Arguments</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_attribute.html</anchorfile>
      <anchor>a761baa935d05d0e987ea8caade1913c8</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>List&lt;(string name, object value)&gt;</type>
      <name>NamedArguments</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_attribute.html</anchorfile>
      <anchor>a59fd94671826fb0821e9c8f0dfeb9405</anchor>
      <arglist></arglist>
    </member>
  </compound>
  <compound kind="class">
    <name>NanoByte::CodeGeneration::CSharpClass</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_c_sharp_class.html</filename>
    <base>NanoByte::CodeGeneration::CSharpInterface</base>
    <member kind="function">
      <type></type>
      <name>CSharpClass</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_class.html</anchorfile>
      <anchor>aaeef53f892978776d4abc2104b527188</anchor>
      <arglist>(CSharpIdentifier identifier)</arglist>
    </member>
    <member kind="function">
      <type>CSharpConstructor</type>
      <name>GetConstruction</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_class.html</anchorfile>
      <anchor>ae0760c632dfdeb6178e67b32fa8b6604</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="protected">
      <type>override ISet&lt; string &gt;</type>
      <name>GetNamespaces</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_class.html</anchorfile>
      <anchor>a0f7da84bc66ac681e4c8563f92cc6a72</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="protected">
      <type>override TypeDeclarationSyntax</type>
      <name>GetTypeDeclaration</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_class.html</anchorfile>
      <anchor>a5742c3b16913808baf93da67ec54c2e6</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="protected">
      <type>override IEnumerable&lt; BaseTypeSyntax &gt;</type>
      <name>GetBaseTypes</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_class.html</anchorfile>
      <anchor>a7556d68d6a6a82d0d3083b7a6ed6b59e</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="protected">
      <type>override IEnumerable&lt; MemberDeclarationSyntax &gt;</type>
      <name>GetMemberDeclarations</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_class.html</anchorfile>
      <anchor>a696d3e66993abc91d3d6150176269709</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="property">
      <type>CSharpConstructor?</type>
      <name>BaseClass</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_class.html</anchorfile>
      <anchor>a0945003767607e270607d8ee3c1bae9a</anchor>
      <arglist></arglist>
    </member>
  </compound>
  <compound kind="class">
    <name>NanoByte::CodeGeneration::CSharpConstructor</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_c_sharp_constructor.html</filename>
    <member kind="function">
      <type></type>
      <name>CSharpConstructor</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_constructor.html</anchorfile>
      <anchor>ae857300059fa905c36872d9ec4d93d49</anchor>
      <arglist>(CSharpIdentifier type)</arglist>
    </member>
    <member kind="function">
      <type>override string</type>
      <name>ToString</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_constructor.html</anchorfile>
      <anchor>a857d4e9e132801342c02a5918c14ae13</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="package">
      <type>IEnumerable&lt; string &gt;</type>
      <name>GetNamespaces</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_constructor.html</anchorfile>
      <anchor>abedbf37349e08f6d139713634d5a939f</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="package">
      <type>ObjectCreationExpressionSyntax</type>
      <name>ToInvocationSyntax</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_constructor.html</anchorfile>
      <anchor>a6ffe3990bcca8e9b815a63b35879bf23</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="package">
      <type>ConstructorDeclarationSyntax</type>
      <name>ToDeclarationSyntax</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_constructor.html</anchorfile>
      <anchor>adc74861f2ac72f5f90677b60965a3062</anchor>
      <arglist>(string typeName)</arglist>
    </member>
    <member kind="property">
      <type>CSharpIdentifier</type>
      <name>Type</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_constructor.html</anchorfile>
      <anchor>a5c68376df50feca74c884558410e828f</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>List&lt; CSharpParameter &gt;</type>
      <name>Parameters</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_constructor.html</anchorfile>
      <anchor>ae3388fda6d97c44046a60c7803b6c9c5</anchor>
      <arglist></arglist>
    </member>
  </compound>
  <compound kind="class">
    <name>NanoByte::CodeGeneration::CSharpEnum</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum.html</filename>
    <base>NanoByte::CodeGeneration::CSharpType</base>
    <member kind="function">
      <type></type>
      <name>CSharpEnum</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum.html</anchorfile>
      <anchor>a2cc66fbe44269b3b19c8205ee7a21eb2</anchor>
      <arglist>(CSharpIdentifier identifier)</arglist>
    </member>
    <member kind="function" protection="protected">
      <type>override MemberDeclarationSyntax</type>
      <name>GetMemberDeclaration</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum.html</anchorfile>
      <anchor>a833934def931537d1383b6d4bc94a52d</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="protected">
      <type>override ISet&lt; string &gt;</type>
      <name>GetNamespaces</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum.html</anchorfile>
      <anchor>a649e632fe4b93405c78904eeabb38a1e</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="property">
      <type>List&lt; CSharpEnumValue &gt;</type>
      <name>Values</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum.html</anchorfile>
      <anchor>a2744260e14e441346f00290652a7e3ae</anchor>
      <arglist></arglist>
    </member>
  </compound>
  <compound kind="class">
    <name>NanoByte::CodeGeneration::CSharpEnumValue</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum_value.html</filename>
    <member kind="function">
      <type></type>
      <name>CSharpEnumValue</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum_value.html</anchorfile>
      <anchor>a42cc211e82199ff54a92d6d63384ea25</anchor>
      <arglist>(string name)</arglist>
    </member>
    <member kind="function">
      <type>override string</type>
      <name>ToString</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum_value.html</anchorfile>
      <anchor>a8e1e3212642c35f375078a9a0f52f27b</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="package">
      <type>IEnumerable&lt; string &gt;</type>
      <name>GetNamespaces</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum_value.html</anchorfile>
      <anchor>a5f767c7a0e920ed39a69fccd138e8d34</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="package">
      <type>EnumMemberDeclarationSyntax</type>
      <name>ToSyntax</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum_value.html</anchorfile>
      <anchor>a61fa012d25c71e4f9a61a4e70b76aab2</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="property">
      <type>string</type>
      <name>Name</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum_value.html</anchorfile>
      <anchor>ade21a0c7c9cbb0dfaf2bdf56cfcf09e4</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>string?</type>
      <name>Summary</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum_value.html</anchorfile>
      <anchor>a2c7d32c0265ea1bb8674c79d673cd116</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>List&lt; CSharpAttribute &gt;</type>
      <name>Attributes</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_enum_value.html</anchorfile>
      <anchor>a6f4bd67bda83216917c96f4a0efdd120</anchor>
      <arglist></arglist>
    </member>
  </compound>
  <compound kind="class">
    <name>NanoByte::CodeGeneration::CSharpIdentifier</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_c_sharp_identifier.html</filename>
    <member kind="function">
      <type></type>
      <name>CSharpIdentifier</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_identifier.html</anchorfile>
      <anchor>a02afd6a18c7d8bc1cf1641c93a628784</anchor>
      <arglist>(string? ns, string name, bool nullable=false)</arglist>
    </member>
    <member kind="function">
      <type>CSharpIdentifier</type>
      <name>ToNullable</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_identifier.html</anchorfile>
      <anchor>a4b4a13b9d4ddc7fd1e4ec9dad81364f5</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function">
      <type>CSharpIdentifier</type>
      <name>ToInterface</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_identifier.html</anchorfile>
      <anchor>a0a48aab869f94af7928103acb2df9486</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function">
      <type>override string</type>
      <name>ToString</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_identifier.html</anchorfile>
      <anchor>a6390283e0a868f8e5c49b6840eba0552</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="package">
      <type>IEnumerable&lt; string &gt;</type>
      <name>GetNamespaces</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_identifier.html</anchorfile>
      <anchor>afbe29e54aa0b96cfb1a27de681b50a46</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="package">
      <type>TypeSyntax</type>
      <name>ToSyntax</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_identifier.html</anchorfile>
      <anchor>acd560a0de864fc64179a28b09d92be2c</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="property">
      <type>string?</type>
      <name>Namespace</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_identifier.html</anchorfile>
      <anchor>a5aac40e995107007d10fe8986e56afce</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>string</type>
      <name>Name</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_identifier.html</anchorfile>
      <anchor>a5f5004d5b9e15b314a47de9158d47007</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>bool</type>
      <name>Nullable</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_identifier.html</anchorfile>
      <anchor>a4320bc8ba2f4ef3d236836150bd0cac2</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>List&lt; CSharpIdentifier &gt;</type>
      <name>TypeArguments</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_identifier.html</anchorfile>
      <anchor>ae85b5594a30ff2a42f353466d829cf73</anchor>
      <arglist></arglist>
    </member>
  </compound>
  <compound kind="class">
    <name>NanoByte::CodeGeneration::CSharpInterface</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_c_sharp_interface.html</filename>
    <base>NanoByte::CodeGeneration::CSharpType</base>
    <member kind="function">
      <type></type>
      <name>CSharpInterface</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_interface.html</anchorfile>
      <anchor>ac1794a17c1fba1e770f5934b3671af02</anchor>
      <arglist>(CSharpIdentifier identifier)</arglist>
    </member>
    <member kind="function" protection="protected">
      <type>override MemberDeclarationSyntax</type>
      <name>GetMemberDeclaration</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_interface.html</anchorfile>
      <anchor>a6b3e3aa716e0677c923edbc5a8e0b9b9</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="protected" virtualness="virtual">
      <type>virtual TypeDeclarationSyntax</type>
      <name>GetTypeDeclaration</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_interface.html</anchorfile>
      <anchor>ac01d0462fed7c2708b5fd926b1637354</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="protected">
      <type>override ISet&lt; string &gt;</type>
      <name>GetNamespaces</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_interface.html</anchorfile>
      <anchor>afffaf60c7e30c9bd8aeb7a4bab8c2c61</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="protected" virtualness="virtual">
      <type>virtual IEnumerable&lt; BaseTypeSyntax &gt;</type>
      <name>GetBaseTypes</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_interface.html</anchorfile>
      <anchor>a6e8ba16159eb9872eb3f8ac3ab9da76d</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="protected" virtualness="virtual">
      <type>virtual IEnumerable&lt; MemberDeclarationSyntax &gt;</type>
      <name>GetMemberDeclarations</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_interface.html</anchorfile>
      <anchor>a96afe9dab667dbf394bfab03bbdd7dda</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="property">
      <type>List&lt; CSharpIdentifier &gt;</type>
      <name>Interfaces</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_interface.html</anchorfile>
      <anchor>aee5ce5467e274c71947d61c1d6d477c5</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>List&lt; CSharpProperty &gt;</type>
      <name>Properties</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_interface.html</anchorfile>
      <anchor>a62cea1796ca9621c8eb6ee47f5c27a70</anchor>
      <arglist></arglist>
    </member>
  </compound>
  <compound kind="class">
    <name>NanoByte::CodeGeneration::CSharpParameter</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_c_sharp_parameter.html</filename>
    <member kind="function">
      <type></type>
      <name>CSharpParameter</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_parameter.html</anchorfile>
      <anchor>addc1c5d6d1ca07eaad6b7ae410fbba89</anchor>
      <arglist>(CSharpIdentifier type, string name)</arglist>
    </member>
    <member kind="function">
      <type>override string</type>
      <name>ToString</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_parameter.html</anchorfile>
      <anchor>afcf7e6b52f68631df53e52e38af73f1e</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="package">
      <type>ParameterSyntax</type>
      <name>ToParameterSyntax</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_parameter.html</anchorfile>
      <anchor>a4dd4126f15e3a14ee649989d7ffb4cda</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="package">
      <type>ArgumentSyntax</type>
      <name>ToArgumentSyntax</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_parameter.html</anchorfile>
      <anchor>aa6904185b46c02becdd3718211fba6b9</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="property">
      <type>CSharpIdentifier</type>
      <name>Type</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_parameter.html</anchorfile>
      <anchor>a5462a9dbf1b4543120d46f1abfa8540c</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>string</type>
      <name>Name</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_parameter.html</anchorfile>
      <anchor>a686eb492a3b96d8f10f1a7f4899fd95e</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>object?</type>
      <name>Value</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_parameter.html</anchorfile>
      <anchor>a939e684db427120962740775f6124efa</anchor>
      <arglist></arglist>
    </member>
    <member kind="property" protection="package">
      <type>bool</type>
      <name>HasLiteralValue</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_parameter.html</anchorfile>
      <anchor>ae451c5e2b91be1aac797908f732eda3f</anchor>
      <arglist></arglist>
    </member>
  </compound>
  <compound kind="class">
    <name>NanoByte::CodeGeneration::CSharpProperty</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_c_sharp_property.html</filename>
    <member kind="function">
      <type></type>
      <name>CSharpProperty</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_property.html</anchorfile>
      <anchor>a63820d62c337ffcb172099eb5015bba9</anchor>
      <arglist>(CSharpIdentifier type, string name)</arglist>
    </member>
    <member kind="function">
      <type>override string</type>
      <name>ToString</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_property.html</anchorfile>
      <anchor>adfd122e80ee62107d3b164d3e7ecefbb</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="package">
      <type>IEnumerable&lt; string &gt;</type>
      <name>GetNamespaces</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_property.html</anchorfile>
      <anchor>a452843c16eb0425ebb2812e80a25e516</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="package">
      <type>PropertyDeclarationSyntax</type>
      <name>ToSyntax</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_property.html</anchorfile>
      <anchor>adfa62647d80803cb3f012b81a2a5db43</anchor>
      <arglist>(bool makePublic=false)</arglist>
    </member>
    <member kind="property">
      <type>CSharpIdentifier</type>
      <name>Type</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_property.html</anchorfile>
      <anchor>ac0988a095d98fac55ccf09e95fdb2b3d</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>string</type>
      <name>Name</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_property.html</anchorfile>
      <anchor>ae9f8f2c95ed02cfdfa69dafd9648b90e</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>string?</type>
      <name>Summary</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_property.html</anchorfile>
      <anchor>ab0a43f74fd07ee39aaff3eafc4aef1cf</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>List&lt; CSharpAttribute &gt;</type>
      <name>Attributes</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_property.html</anchorfile>
      <anchor>ab097e3e3b4496489f0cbe02335488ba6</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>CSharpConstructor?</type>
      <name>Initializer</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_property.html</anchorfile>
      <anchor>a519c50039d7c1f9c807e2336a5d9cb2d</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>CSharpConstructor?</type>
      <name>GetterExpression</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_property.html</anchorfile>
      <anchor>a62b8415a101c28aee0a5cbfa4023ec7d</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>bool</type>
      <name>HasSetter</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_property.html</anchorfile>
      <anchor>a84fa32c0eee5c93e0d6eb92e2fc756d6</anchor>
      <arglist></arglist>
    </member>
  </compound>
  <compound kind="class">
    <name>NanoByte::CodeGeneration::CSharpType</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_c_sharp_type.html</filename>
    <base>NanoByte::CodeGeneration::ICSharpType</base>
    <member kind="function">
      <type>CompilationUnitSyntax</type>
      <name>ToSyntax</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_type.html</anchorfile>
      <anchor>aee9b70c1756b68b3b628dadd68235d10</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function">
      <type>override string</type>
      <name>ToString</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_type.html</anchorfile>
      <anchor>ad5d28f11e93793b32076a0c3404086ac</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="protected">
      <type></type>
      <name>CSharpType</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_type.html</anchorfile>
      <anchor>ae488e2e078af5f831221f30533450f18</anchor>
      <arglist>(CSharpIdentifier identifier)</arglist>
    </member>
    <member kind="function" protection="protected" virtualness="virtual">
      <type>virtual ISet&lt; string &gt;</type>
      <name>GetNamespaces</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_type.html</anchorfile>
      <anchor>a116d967d1c39cf1d89e9a73d9f8a0e69</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="function" protection="protected" virtualness="pure">
      <type>abstract MemberDeclarationSyntax</type>
      <name>GetMemberDeclaration</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_type.html</anchorfile>
      <anchor>a1c062d9dc20aec4ba332e91ded86c292</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="property">
      <type>CSharpIdentifier</type>
      <name>Identifier</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_type.html</anchorfile>
      <anchor>a812a39f33a18a7df6b0afac4c66b9e83</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>string?</type>
      <name>Summary</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_type.html</anchorfile>
      <anchor>ab0eab4fb8ca7896d2a1da0ede9a359f5</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>List&lt; CSharpAttribute &gt;</type>
      <name>Attributes</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_type.html</anchorfile>
      <anchor>a5f36686d11863738f0ac881f5539206f</anchor>
      <arglist></arglist>
    </member>
  </compound>
  <compound kind="class">
    <name>NanoByte::CodeGeneration::CSharpTypeExtensions</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_c_sharp_type_extensions.html</filename>
    <member kind="function" static="yes">
      <type>static void</type>
      <name>WriteToFile</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_type_extensions.html</anchorfile>
      <anchor>a0b94cad26df28bd5225705f064bdf8b4</anchor>
      <arglist>(this ICSharpType type, string path)</arglist>
    </member>
    <member kind="function" static="yes">
      <type>static void</type>
      <name>WriteToDirectory</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_c_sharp_type_extensions.html</anchorfile>
      <anchor>ad2217d4f6b8443852f79b6b20f724d12</anchor>
      <arglist>(this ICSharpType type, string path)</arglist>
    </member>
  </compound>
  <compound kind="interface">
    <name>NanoByte::CodeGeneration::ICSharpType</name>
    <filename>interface_nano_byte_1_1_code_generation_1_1_i_c_sharp_type.html</filename>
    <member kind="function">
      <type>CompilationUnitSyntax</type>
      <name>ToSyntax</name>
      <anchorfile>interface_nano_byte_1_1_code_generation_1_1_i_c_sharp_type.html</anchorfile>
      <anchor>ac3397e5124d4d62c8c5640174fba80ac</anchor>
      <arglist>()</arglist>
    </member>
    <member kind="property">
      <type>CSharpIdentifier</type>
      <name>Identifier</name>
      <anchorfile>interface_nano_byte_1_1_code_generation_1_1_i_c_sharp_type.html</anchorfile>
      <anchor>a2fdc5e78ea9c3b3557308f1038bad280</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>string?</type>
      <name>Summary</name>
      <anchorfile>interface_nano_byte_1_1_code_generation_1_1_i_c_sharp_type.html</anchorfile>
      <anchor>a5b5b4d771b85caa26d8c8d746152a7cf</anchor>
      <arglist></arglist>
    </member>
    <member kind="property">
      <type>List&lt; CSharpAttribute &gt;</type>
      <name>Attributes</name>
      <anchorfile>interface_nano_byte_1_1_code_generation_1_1_i_c_sharp_type.html</anchorfile>
      <anchor>a40bd237307cd4b06c0b4039624ec4c58</anchor>
      <arglist></arglist>
    </member>
  </compound>
  <compound kind="class">
    <name>NanoByte::CodeGeneration::SyntaxExtensions</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_syntax_extensions.html</filename>
    <member kind="function" protection="package" static="yes">
      <type>static TSyntax</type>
      <name>WithDocumentation&lt; TSyntax &gt;</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_syntax_extensions.html</anchorfile>
      <anchor>a565917d22158a34b950f82840aa5b3f2</anchor>
      <arglist>(this TSyntax node, string? summary)</arglist>
    </member>
    <member kind="function" protection="package" static="yes">
      <type>static LiteralExpressionSyntax</type>
      <name>ToLiteralSyntax</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_syntax_extensions.html</anchorfile>
      <anchor>a649b67c390e3389b38cae466f1f20839</anchor>
      <arglist>(this object value)</arglist>
    </member>
  </compound>
  <compound kind="class">
    <name>NanoByte::CodeGeneration::ThisReference</name>
    <filename>class_nano_byte_1_1_code_generation_1_1_this_reference.html</filename>
    <member kind="function">
      <type>override string</type>
      <name>ToString</name>
      <anchorfile>class_nano_byte_1_1_code_generation_1_1_this_reference.html</anchorfile>
      <anchor>a13bc86980cb8136341698152403318fe</anchor>
      <arglist>()</arglist>
    </member>
  </compound>
  <compound kind="namespace">
    <name>NanoByte::CodeGeneration</name>
    <filename>namespace_nano_byte_1_1_code_generation.html</filename>
    <class kind="class">NanoByte::CodeGeneration::CSharpAttribute</class>
    <class kind="class">NanoByte::CodeGeneration::CSharpClass</class>
    <class kind="class">NanoByte::CodeGeneration::CSharpConstructor</class>
    <class kind="class">NanoByte::CodeGeneration::CSharpEnum</class>
    <class kind="class">NanoByte::CodeGeneration::CSharpEnumValue</class>
    <class kind="class">NanoByte::CodeGeneration::CSharpIdentifier</class>
    <class kind="class">NanoByte::CodeGeneration::CSharpInterface</class>
    <class kind="class">NanoByte::CodeGeneration::CSharpParameter</class>
    <class kind="class">NanoByte::CodeGeneration::CSharpProperty</class>
    <class kind="class">NanoByte::CodeGeneration::CSharpType</class>
    <class kind="class">NanoByte::CodeGeneration::CSharpTypeExtensions</class>
    <class kind="interface">NanoByte::CodeGeneration::ICSharpType</class>
    <class kind="class">NanoByte::CodeGeneration::SyntaxExtensions</class>
    <class kind="class">NanoByte::CodeGeneration::ThisReference</class>
  </compound>
  <compound kind="page">
    <name>index</name>
    <title></title>
    <filename>index.html</filename>
    <docanchor file="index.html">md_D__a_code_generation_code_generation_doc_main</docanchor>
  </compound>
</tagfile>
