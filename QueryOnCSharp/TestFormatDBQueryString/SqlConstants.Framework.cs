// =================================================================================================
// <copyright file="SqlConstants.Framework.cs">
//   © 2017 Quest Software Inc.
//   ALL RIGHTS RESERVED.
// </copyright>

// =================================================================================================
// Owner:	Stephen Pope
// Status:	Creating

// =================================================================================================
// REFERENCES

using System;

// =================================================================================================
// CLASSES

namespace Quest.Spotlight.SOM.Common.GeneralLibraries.ConstantsLibrary
{
	public static partial class SqlConstants
	{
		// -----------------------------------------------------------------------------------------
		// Types

		public static class Framework
		{
			// -------------------------------------------------------------------------------------
			// Types

			public static class Actions
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName = "T_Actions";

				public static readonly String Id = "ActionId";
				public static readonly String Name = "ActionName";
				public static readonly String PlugInId = "PlugInId";
				public static readonly String IsGroup = "IsGroup";
				public static readonly String OrderIndex = "OrderIndex";
				public static readonly String IsSeparator = "IsSeparator";

				public static readonly String PredefinedActionName =
					"PredefinedActionName";
				public static readonly String Location = "Location";
				public static readonly String HideInTreeView = "HideInTreeView";
				public static readonly String HideInTopologyView =
					"HideInTopologyView";
				public static readonly String HideInResultView =
					"HideInResultView";
				public static readonly String GroupId = "GroupId";
				public static readonly String RenderAsRegion =
					"RenderAsRegion";
				public static readonly String AssemblyName = "AssemblyName";
				public static readonly String ClassName = "ClassName";
				public static readonly String ResourceSetName =
					"ResourceSetName";
				public static readonly String CaptionResourceName =
					"CaptionResourceName";
				public static readonly String IconResourceName =
					"IconResourceName";
				public static readonly String DescriptionResourceName =
					"DescriptionResourceName";

				// ---------------------------------------------------------------------------------
				// Types

				public static class ReservedPredefinedActionName
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly String Copy = "Copy";
					public static readonly String Cut = "Cut";
					public static readonly String Delete = "Delete";
					public static readonly String Paste = "Paste";
					public static readonly String Print = "Print";
					public static readonly String Properties = "Properties";
					public static readonly String Refresh = "Refresh";
					public static readonly String Rename = "Rename";
				}

				public enum LocationValue
				{
					TopLevel = 0,
					ViewExtension = 1,
					ViewMenu = 2,
					HelpMenu = 3,
				}
			}

			public static class ActionMap
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ActionToManagedObjectTypeMap";

				public static readonly String ActionId = "ActionId";
				public static readonly String ManagedObjectTypeId =
					"ManagedObjectTypeId";
			}

			public static class Credentials
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_Credentials";

				public static readonly String CredentialsId = "CredentialsId";
				public static readonly String UserName = "UserName";
				public static readonly String Password = "Password";
			}

			public static class DefaultTestSettings
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_DefaultTestSettings";

				public static readonly String ExecutionMode = "ExecutionMode";
				public static readonly String ExecutionFrequency =
					"ExecutionFrequencyInMilliseconds";
				public static readonly String ExecuteOncePerDayTime =
					"ExecuteOncePerDayTimeInMillisecondsFromMidnight";
				public static readonly String UseExecutionWindow =
					"UseExecutionWindow";
				public static readonly String ExecutionWindowStartTime =
					"ExecutionWindowStartTimeInMillisecondsFromMidnight";
				public static readonly String ExecutionWindowEndTime =
					"ExecutionWindowEndTimeInMillisecondsFromMidnight";
				public static readonly String NotificationGroupId =
					"NotificationGroupId";

				// TODO: Remove constant
				[Obsolete]
				public static readonly String MaximumNotificationsPerAlarm =
					"MaximumNotificationsPerAlarm";

				// TODO: Remove constant
				[Obsolete]
				public static readonly String NotificationAlarmThresholdCount =
					"NotificationAlarmThresholdCount";
				public static readonly String CredentialsId = "CredentialsId";
				public static readonly String ForwardAlertsToOperationsManager =
					"ForwardAlertsToOperationsManager";

				// ---------------------------------------------------------------------------------
				// Types

				public enum ExecutionModeValue
				{
					Unknown = -1,
					Once = 0,
					Continuously = 1,
					OnceDaily = 2,
				}
			}

			public static class DistributedCollectorAssignments
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_DistributedCollectorAssignments";

				public static readonly String AssignmentId = "AssignmentId";
				public static readonly String CollectorId = "CollectorId";
				public static readonly String ResourceId = "ResourceId";
				public static readonly String ResourceType = "ResourceType";
			}

			public static class DistributedCollectorDomains
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_DistributedCollectorDomains";

				public static readonly String DomainId = "CollectorDomainId";
				public static readonly String DisplayName = "DisplayName";
				public static readonly String ForestId = "CollectorForestId";
				public static readonly String ResourceType = "ResourceType";
			}

			public static class DistributedCollectorForests
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_DistributedCollectorForests";

				public static readonly String ForestId = "CollectorForestId";
				public static readonly String DisplayName = "DisplayName";
			}

			public static class DistributedCollectors
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_DistributedCollectors";

				public static readonly String CollectorId = "CollectorId";
				public static readonly String CollectorName = "CollectorName";
				public static readonly String HostServerFqdn = "HostServerFQDN";
				public static readonly String ListeningPort = "ListeningPort";
				public static readonly String IsDefault = "IsDefault";
			}

			public static class DistributedCollectorServers
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_DistributedCollectorServers";

				public static readonly String ServerId = "CollectorServerId";
				public static readonly String DomainId = "CollectorDomainId";
				public static readonly String ForestId = "CollectorForestId";
				public static readonly String SiteId = "CollectorSiteId";

				// ENHANCEMENT: Change name to something more generic
				public static readonly String FullyQualifiedDomainName =
					"FullyQualifiedDomainName";
				public static readonly String DisplayName = "DisplayName";
			}

			public static class DistributedCollectorSites
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_DistributedCollectorSites";

				public static readonly String SiteId = "CollectorSiteId";
				public static readonly String DisplayName = "DisplayName";
				public static readonly String ForestId = "CollectorForestId";
			}

			public static class DynamicCustomGroupProperties
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_DynamicCustomGroupProperties";

				public static readonly String ManagedObjectId =
					"ManagedObjectId";
				public static readonly String DynamicCustomGroupQuery =
					"DynamicCustomGroupQuery";
				public static readonly String DynamicCustomGroupConfiguration =
					"DynamicCustomGroupConfiguration";
			}

			public static class CustomGroupProperties
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_Framework_CustomGroupProperties";

				public static readonly String ManagedObjectId =
					"ManagedObjectId";
				public static readonly String HierarchyViewMode =
					"HierarchyViewMode";
			}

			public static class GlobalSettings
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName = "T_GlobalSettings";

				public static readonly String Key = "Key";
				public static readonly String Value = "Value";

				// ---------------------------------------------------------------------------------
				// Types

				public static class KeyName
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly String DatabaseRetentionInDays =
						"DatabaseRetentionInDays";

					public static readonly String ReportsDailyRetentionInDays =
						"ReportsDailyRetentionInDays";

					public static readonly String ReportsHourlyRetentionInDays =
						"ReportsHourlyRetentionInDays";

					public static readonly String TestHistoryRetentionInDays =
						"TestHistoryRetentionInDays";

					public static readonly String
						OperationsManagerDatabaseServer =
							"OperationsManagerDatabaseServer";

					public static readonly String
						OperationsManagerConnectorFrameworkServer =
							"OperationsManagerConnectorFrameworkServer";

					public static readonly String
						NotificationPrimarySmtpServer =
							"NotificationSmtpServer";

					public static readonly String
						NotificationSecondarySmtpServer =
							"NotificationSecondarySmtpServer";

					public static readonly String TestResultsViewHideColumns =
						"TestResultsViewHideColumns";
				}
			}

			public static class InfrastructureConnections
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_InfrastructureConnections";

				public static readonly String Id = "InfrastructureConnectionId";
				public static readonly String DisplayName = "DisplayName";
				public static readonly String UniqueName = "UniqueName";
				public static readonly String TargetName = "TargetName";
				public static readonly String TargetHintName = "TargetHintName";
				public static readonly String PlugInId = "PlugInId";
				public static readonly String HaveDiscoveryData =
					"HaveDiscoveryData";
				public static readonly String IsAutoDiscoveryEnabled =
					"IsAutoDiscoveryEnabled";
				public static readonly String AutoDiscoveryTime =
					"AutoDiscoveryTimeInMillisecondsFromMidnight";
				public static readonly String AutoDiscoveryInterval =
					"AutoDiscoveryIntervalInMilliseconds";
				public static readonly String
					PrimaryInfrastructureConnectionId =
						"PrimaryInfrastructureConnectionId";
			}

			public static class ManagedObjectGenericServerProperties
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ManagedObjectGenericServerProperties";

				public static readonly String ManagedObjectId =
					"ManagedObjectId";
				public static readonly String OperatingSystem =
					"OperatingSystem";
				public static readonly String ServicePack = "ServicePack";
			}

			public static class ManagedObjectHierarchy
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ManagedObjectHierarchy";

				public static readonly String Id = "ManagedObjectId";
				public static readonly String ChildId = "ManagedObjectChildId";
				public static readonly String HierarchyViewMode =
					"HierarchyViewMode";

				// ---------------------------------------------------------------------------------
				// Types

				public static class HierarchyViewModeValue
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly Int32 Framework = 0;
				}
			}

			public static class ManagedObjectLinks
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String
					TableName = "T_ManagedObjectLinks";

				public static readonly String RepresentativeManagedObjectId =
					"RepresentativeManagedObjectId";
				public static readonly String SourceManagedObjectId =
					"SourceManagedObjectId";
				public static readonly String DestinationManagedObjectId =
					"DestinationManagedObjectId";
				public static readonly String LinkDirection =
					"LinkDirection";

				// ---------------------------------------------------------------------------------
				// Types

				// TODO: Rename to LinkDirectionValue
				public enum LinkDirectionType
				{
					None = 0,
					Destination = 1,
					Source = 2,
					Both = 3,
				}
			}

			// All property secondary host tables need to have an 
			// infrastructure connection ID
			public static class ManagedObjectPropertySecondaryHostTable
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String InfrastructureConnectionId =
					"InfrastructureConnectionId";
			}

			public static class ManagedObjectPropertyTypes
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ManagedObjectPropertyTypes";

				public static readonly String Id =
					"ManagedObjectPropertyTypeId";
				public static readonly String Name =
					"PropertyTypeName";
				public static readonly String PlugInId = "PlugInId";
				public static readonly String PrimaryHostTable =
					"PrimaryHostTable";
				public static readonly String PrimaryHostTableColumnName =
					"PrimaryHostTableColumnName";
				public static readonly String SecondaryHostTable =
					"SecondaryHostTable";
				public static readonly String SecondaryHostTableKeyColumnName =
					"SecondaryHostTableKeyColumnName";
				public static readonly String
					SecondaryHostTableValueColumnName =
						"SecondaryHostTableValueColumnName";
				public static readonly String IsSearchable = "IsSearchable";
				public static readonly String IsVisibleByDefault =
					"IsVisibleByDefault";
				public static readonly String IsInternal = "IsInternal";
				public static readonly String IsCustomizable = "IsCustomizable";
				public static readonly String OrderIndex = "OrderIndex";
				public static readonly String DefaultColumnWidth =
					"DefaultColumnWidth";
				public static readonly String AssemblyName = "AssemblyName";
				public static readonly String ResourceSetName =
					"ResourceSetName";
				public static readonly String CaptionResourceName =
					"CaptionResourceName";

				// ---------------------------------------------------------------------------------
				// Types

				public static class ManagedObjectPropertyTypeValues
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly String
						FrameworkCustomGroupHierarchy =
							"Framework.CustomGroupHierarchy";
				}

				public static class PropertyTypeNames
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly String DynamicCustomGroupQuery =
						"DynamicCustomGroupQuery";
					public static readonly String
						DynamicCustomGroupConfiguration =
							"DynamicCustomGroupConfiguration";
					public static readonly String GenericPropertyDisplayName =
						"GenericProperty.DisplayName";
					public static readonly String GenericPropertyName =
						"GenericProperty.Name";
				}
			}

			public static class ManagedObjectPropertyTypeMap
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ManagedObjectPropertyTypeToManagedObjectTypeMap";

				public static readonly String PropertyTypeId =
					"ManagedObjectPropertyTypeId";
				public static readonly String ManagedObjectTypeId =
					"ManagedObjectTypeId";
			}

			public static class ManagedObjects
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName = "T_ManagedObjects";

				public static readonly String Id = "ManagedObjectId";
				public static readonly String Name = "ManagedObjectName";
				public static readonly String DisplayName =
					"ManagedObjectDisplayName";
				public static readonly String InfrastructureConnectionId =
					"InfrastructureConnectionId";
				public static readonly String IsManualObject = "IsManualObject";
				public static readonly String IsObjectMissing =
					"IsObjectMissing";
				public static readonly String InMaintenanceMode =
					"InMaintenanceMode";

				// ---------------------------------------------------------------------------------
				// Types

				public static class ReservedName
				{
					// -----------------------------------------------------------------------------
					// Constants

					// TODO: Update to follow naming convention
					public static readonly String GroupContainerName =
						"Custom Groups";
				}
			}

			public static class ManagedObjectMap
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String
					TableName = "T_ManagedObjectToManagedObjectTypeMap";

				public static readonly String ManagedObjectId =
					"ManagedObjectId";
				public static readonly String ManagedObjectTypeId =
					"ManagedObjectTypeId";
			}

			public static class ManagedObjectTestTargetProperties
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ManagedObjectTestTargetProperties";

				public static readonly String Id = "ManagedObjectId";
				public static readonly String DomainId = "TestTargetDomainId";
				public static readonly String ForestId = "TestTargetForestId";
				public static readonly String SiteId = "TestTargetSiteId";
			}

			public static class ManagedObjectTestTargetDomains
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ManagedObjectTestTargetDomains";

				public static readonly String Id = "TestTargetDomainId";
				public static readonly String InfrastructureConnectionId =
					"InfrastructureConnectionId";
				public static readonly String DomainDisplayName =
					"DomainDisplayName";
				public static readonly String DomainFullyQualifiedName =
					"DomainFullyQualifiedName";
			}

			public static class ManagedObjectTestTargetForests
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ManagedObjectTestTargetForests";

				public static readonly String ForestId = "TestTargetForestId";
				public static readonly String InfrastructureConnectionId =
					"InfrastructureConnectionId";
				public static readonly String ForestDisplayName =
					"ForestDisplayName";
				public static readonly String ForestFullyQualifiedName =
					"ForestFullyQualifiedName";
			}

			public static class ManagedObjectTestTargetSites
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ManagedObjectTestTargetSites";

				public static readonly String SiteId = "TestTargetSiteId";
				public static readonly String InfrastructureConnectionId =
					"InfrastructureConnectionId";
				public static readonly String SiteDisplayName =
					"SiteDisplayName";
				public static readonly String SiteFullyQualifiedName =
					"SiteFullyQualifiedName";
			}

			public static class ManagedObjectTypeHierarchy
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ManagedObjectTypeHierarchy";

				public static readonly String Id = "ManagedObjectTypeId";
				public static readonly String ChildId =
					"ManagedObjectTypeChildId";
			}

			public static class ManagedObjectTypes
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ManagedObjectTypes";

				public static readonly String Id = "ManagedObjectTypeId";
				public static readonly String Name = "ManagedObjectTypeName";
				public static readonly String PlugInId = "PlugInId";
				public static readonly String IsGroup = "IsGroup";
				public static readonly String IsTestTarget = "IsTestTarget";
				public static readonly String IsSearchable = "IsSearchable";
				public static readonly String IsLink = "IsLink";
				public static readonly String ShowInCustomGroups =
					"ShowInCustomGroups";
				public static readonly String ShowTopologyView =
					"ShowTopologyView";
				public static readonly String ShowInTopology =
					"ShowInTopology";
				public static readonly String VisibilityViewMask =
					"VisibilityViewMask";
				public static readonly String OrderIndex =
					"OrderIndex";
				public static readonly String ShouldRemoveMissingObjects =
					"ShouldRemoveMissingObjects";
				public static readonly String HelpTopicName = "HelpTopicName";
				public static readonly String AssemblyName = "AssemblyName";
				public static readonly String ResourceSetName =
					"ResourceSetName";
				public static readonly String IconResourceName =
					"IconResourceName";
				public static readonly String CaptionResourceName =
					"CaptionResourceName";
				public static readonly String ShowInTreeView =
					"ShowInTreeView";

				// ---------------------------------------------------------------------------------
				// Types

				public static class VisibilityViewMaskValue
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly Int32 All = Int32.MaxValue;
				}

				public enum OrderIndexValue
				{
					Root = 0,
					Group = 10,
					Server = 20,
					CustomGroup = 100,
					Link = 200,
				}

				public static class ReservedName
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly String Root =
						"Framework.Root";

					// TODO: Update to follow naming convention
					public static readonly String GroupContainer =
						"Custom Group Container";

					// TODO: Update to follow naming convention
					public static readonly String StaticGroup =
						"Static Custom Group";

					// TODO: Update to follow naming convention
					public static readonly String DynamicGroup =
						"Dynamic Custom Group";

					public static readonly String CustomGroupSuffix =
						"CustomGroup";
				}
			}

			public static class NotificationGroupRecipients
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_NotificationGroupRecipients";

				public static readonly String GroupId =
					"NotificationGroupId";
				public static readonly String RecipientId =
					"NotificationRecipientId";
			}

			public static class NotificationGroups
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_NotificationGroups";

				public static readonly String Id = "NotificationGroupId";
				public static readonly String DisplayName = "DisplayName";
				public static readonly String SendEmailAddress =
					"SendEmailAddress";
				public static readonly String ExternalApplications =
					"ExternalApplications";
				public static readonly String NotifyOnAlertCleared =
					"NotifyOnAlertCleared";
				public static readonly String SendUnlimitedNotifications =
					"SendUnlimitedNotifications";
				public static readonly String MaxNotificationCount =
					"MaxNotificationCount";
				public static readonly Int32 DefaultNotificationCount = 3;
				public static readonly Int32 MinimumNotificationCount = 1;
				public static readonly Int32 MaximumNotificationCount = 999;

				public static readonly String NotificationSustainCount =
					"SustainCount";
				public static readonly Int32 DefaultSustainCount = 0;
				public static readonly Int32 MinimumSustainCount = 0;
				public static readonly Int32 MaximumSustainCount = 999;
			}

			public static class NotificationCredentials
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName = "T_NotificationCredentials";

				public static readonly String Id = "NotificationCredentialId";
				public static readonly String AccountName = "AccountName";
				public static readonly String Password = "Password";
			}

			public static class NotificationGroupCredentials
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName = "T_NotificationGroupCredentials";
				public static readonly String GroupId = "NotificationGroupId";
				public static readonly String CredentialId = "NotificationCredentialId";
			}

			public static class NotificationRecipients
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_NotificationRecipients";

				public static readonly String Id = "NotificationRecipientId";
				public static readonly String Name = "Name";
				public static readonly String EmailAddress = "EmailAddress";
				public static readonly String MessageType = "MessageType";
				public static readonly String SeverityLevel =
					"NotificationSeverityLevel";
				public static readonly String IsCredentialUsed = "IsCredentialUsed";
				public static readonly String SenderEmailAddress = "SenderEmailAddress";
				public static readonly String EmailAddressOfCredential = "EmailAddressOfCredential";

				// ---------------------------------------------------------------------------------
				// Types

				public enum MessageTypeValue
				{
					PlainText = 1,
					Html = 2
				}

				// TODO: Rename to SeverityLevelValue
				public enum SeverityLevelTypeValue
				{
					Errors = 1,
					ErrorsAndWarnings = 2
				}
			}

			public static class PlugInHomePages
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_PlugInHomePages";

				public static readonly String Id = "PlugInId";
				public static readonly String AssemblyName = "AssemblyName";
				public static readonly String ClassName = "ClassName";
			}

			public static class PlugIns
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_PlugIns";

				public static readonly String Id = "PlugInId";
				public static readonly String Name = "PlugInName";
				public static readonly String Version = "PlugInVersion";
				public static readonly String DefaultHierarchyViewMode =
					"DefaultHierarchyViewMode";
				public static readonly String DefaultVisibilityViewMask =
					"DefaultVisibilityViewMask";

				// ---------------------------------------------------------------------------------
				// Types

				public class ReservedName
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly String Framework = "Framework";
					public static readonly String Exchange = "Exchange";
					public static readonly String BlackBerry = "BlackBerry";
					public static readonly String OCS = "OCS";
				}
			}

			public static class PlugInLicensing
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_PlugInLicenseProviders";

				public static readonly String PlugInId = "PlugInId";
				public static readonly String AssemblyName = "AssemblyName";
				public static readonly String ClassName = "ClassName";
			}

			public static class ReportCounterInstances
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ReportCounterInstances";
				public static readonly String Id =
					"ReportCounterInstanceId";
				public static readonly String ManagedObjectId =
					"ManagedObjectId";
				public static readonly String ReportCounterTypeId =
					"ReportCounterTypeId";
				public static readonly String InstanceDisplayName =
					"InstanceDisplayName";
				public static readonly String GroupDisplayName =
					"GroupDisplayName";
			}

			public static class ReportCounterTypes
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ReportCounterTypes";
				public static readonly String Id =
					"ReportCounterTypeId";
				public static readonly String CounterDisplayName =
					"CounterDisplayName";
				public static readonly String CounterInternalName =
					"CounterInternalName";
			}

			public static class ReportCounterValues
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ReportCounterValues";
				public static readonly String ReportCounterInstanceId =
					"ReportCounterInstanceId";
				public static readonly String Value =
					"CounterValue";
				public static readonly String UpdateDateTime =
					"UpdateDateTime";
				public static readonly String TestGroupId =
					"TestGroupId";
			}

			public static class ReportDailyCounterValues
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ReportDailyCounterValues";
				public static readonly String ReportCounterInstanceId =
					"ReportCounterInstanceId";
				public static readonly String UpdateDateTime =
					"UpdateDateTime";
				public static readonly String Value =
					"CounterValue";
				public static readonly String RecordCount =
					"NumRecords";
			}

			public static class ReportHourlyCounterValues
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_ReportHourlyCounterValues";
				public static readonly String ReportCounterInstanceId =
					"ReportCounterInstanceId";
				public static readonly String UpdateDateTime =
					"UpdateDateTime";
				public static readonly String Value =
					"CounterValue";
				public static readonly String RecordCount =
					"NumRecords";
			}

			public static class TestCounters
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_TestCounters";
				public static readonly String CounterId =
					"CounterId";
				public static readonly String TestTypeId =
					"TestTypeId";
				public static readonly String ManagedObjectTypeName =
					"ManagedObjectTypeName";
				public static readonly String CounterPath =
					"CounterPath";
				public static readonly String ErrorThresholdPath =
					"ErrorThresholdPath";
				public static readonly String WarningThresholdPath =
					"WarningThresholdPath";
			}

			public static class TestResultHistory
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_TestResultHistory";
				public static readonly String TestGroupId =
					TestGroups.Id;
				public static readonly String ManagedObjectId =
					ManagedObjects.Id;
				public static readonly String StartTime =
					"StartTime";
				public static readonly String CompletionTime =
					"CompletionTime";
				public static readonly String OverallTestResult =
					"OverallTestResult";
				public static readonly String TestResults =
					"TestResults";
			}

			public static class TestGroups
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName = "T_TestGroups";

				public static readonly String Id = "TestGroupId";
				public static readonly String Configuration =
					"TestGroupConfiguration";
				public static readonly String Status = "TestGroupStatus";
				public static readonly String TestTypeId = "TestTypeId";
				public static readonly String InfrastructureConnectionId =
					"InfrastructureConnectionId";
			}

			public static class Tests
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName = "T_Tests";

				public static readonly String Id = "TestId";
				public static readonly String GroupId = "TestGroupId";
				public static readonly String Configuration =
					"TestConfiguration";
				public static readonly String ManagedObjectId =
					"ManagedObjectId";
			}

			public static class TestTypes
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName = "T_TestTypes";

				public static readonly String Id = "TestTypeId";
				public static readonly String Name = "TestTypeName";
				public static readonly String PlugInId = "PlugInId";
				public static readonly String EditTestActionId =
					"EditTestActionId";

				// TODO: Not used, should be removed
				[Obsolete]
				public static readonly String AssemblyName = "AssemblyName";

				// TODO: Not used, should be removed
				[Obsolete]
				public static readonly String ResourceSetName =
					"ResourceSetName";
			}

			public static class TestTypeTargetMap
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName = "T_TestTypeTargetMap";

				public static readonly String TestTypeId = "TestTypeId";
				public static readonly String ManagedObjectTypeId =
					"ManagedObjectTypeId";
			}

			public static class TestTypeActionMap
			{
				// ---------------------------------------------------------------------------------
				// Constants

				public static readonly String TableName =
					"T_TestTypeToActionMap";

				public static readonly String TestTypeId = "TestTypeId";
				public static readonly String ActionId = "ActionId";
			}

			public static class UserFunctions
			{
				// ---------------------------------------------------------------------------------
				// Types

				public static class GetManagedObjectTypeIds
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly String FunctionName =
						"dbo.UF_GetManagedObjectTypeIds";

					public static readonly String ReturnParameterName =
						"ManagedObjectTypeIds";

					public static readonly Char ReturnParameterSeparator = '|';
				}
			}

			public static class StoredProcedures
			{
				// ---------------------------------------------------------------------------------
				// Types

				public static class PurgeTestResultsHistory
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly String FunctionName =
						"dbo.sp_PurgeTestResultsHistory";
				}

				public static class PurgeWebReportsData
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly String FunctionName =
						"dbo.sp_PurgeWebReportsData";
				}
			}

			[Obsolete]
			public static class Reports
			{
				// ---------------------------------------------------------------------------------
				// Types

				[Obsolete("Use ReportCounterTypes constants instead")]
				public static class CounterTypes
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly String TableName =
						"T_ReportCounterTypes";
					public static readonly String CounterId =
						"ReportCounterTypeId";
					public static readonly String ManagedObjectId =
						"ManagedObjectId";
					public static readonly String CounterName =
						"CounterName";
				}

				[Obsolete("Use ReportCounterValues constants instead")]
				public static class CounterValues
				{
					// -----------------------------------------------------------------------------
					// Constants

					public static readonly String TableName =
						"T_ReportCounterValues";
					public static readonly String CounterId =
						"ReportCounterTypeId";
					public static readonly String Value =
						"CounterValue";
				}
			}
		}
	}
}