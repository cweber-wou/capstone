<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="RDImageGallery" generation="1" functional="0" release="0" Id="56d71e2d-a55e-497a-bc64-a55fe199b1cb" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="RDImageGalleryGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="FileUploader_WebRole:HttpIn" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/RDImageGallery/RDImageGalleryGroup/LB:FileUploader_WebRole:HttpIn" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="FileUploader_WebRole:ContainerName" defaultValue="">
          <maps>
            <mapMoniker name="/RDImageGallery/RDImageGalleryGroup/MapFileUploader_WebRole:ContainerName" />
          </maps>
        </aCS>
        <aCS name="FileUploader_WebRole:DataConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/RDImageGallery/RDImageGalleryGroup/MapFileUploader_WebRole:DataConnectionString" />
          </maps>
        </aCS>
        <aCS name="FileUploader_WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/RDImageGallery/RDImageGalleryGroup/MapFileUploader_WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="FileUploader_WebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/RDImageGallery/RDImageGalleryGroup/MapFileUploader_WebRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:FileUploader_WebRole:HttpIn">
          <toPorts>
            <inPortMoniker name="/RDImageGallery/RDImageGalleryGroup/FileUploader_WebRole/HttpIn" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapFileUploader_WebRole:ContainerName" kind="Identity">
          <setting>
            <aCSMoniker name="/RDImageGallery/RDImageGalleryGroup/FileUploader_WebRole/ContainerName" />
          </setting>
        </map>
        <map name="MapFileUploader_WebRole:DataConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/RDImageGallery/RDImageGalleryGroup/FileUploader_WebRole/DataConnectionString" />
          </setting>
        </map>
        <map name="MapFileUploader_WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/RDImageGallery/RDImageGalleryGroup/FileUploader_WebRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapFileUploader_WebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/RDImageGallery/RDImageGalleryGroup/FileUploader_WebRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="FileUploader_WebRole" generation="1" functional="0" release="0" software="C:\Users\Acidraven\Desktop\CS430\Nfficiency_Plagiarism_Checker\FileUploaderProject\RDImageGallery\csx\Debug\roles\FileUploader_WebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="HttpIn" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="ContainerName" defaultValue="" />
              <aCS name="DataConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;FileUploader_WebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;FileUploader_WebRole&quot;&gt;&lt;e name=&quot;HttpIn&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/RDImageGallery/RDImageGalleryGroup/FileUploader_WebRoleInstances" />
            <sCSPolicyFaultDomainMoniker name="/RDImageGallery/RDImageGalleryGroup/FileUploader_WebRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="FileUploader_WebRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="FileUploader_WebRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="99090527-f423-449a-825d-aedd18847613" ref="Microsoft.RedDog.Contract\ServiceContract\RDImageGalleryContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="9ade3649-d8c1-412e-971b-c5a4f9cc179f" ref="Microsoft.RedDog.Contract\Interface\FileUploader_WebRole:HttpIn@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/RDImageGallery/RDImageGalleryGroup/FileUploader_WebRole:HttpIn" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>