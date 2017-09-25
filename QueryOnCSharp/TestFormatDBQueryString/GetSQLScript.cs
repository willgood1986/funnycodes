using Quest.Spotlight.SOM.Common.GeneralLibraries.ConstantsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormatDBQueryString
{
    class GetSQLScript
    {
        internal static String GetQueryString()
        {
            String query = String.Format(
            "SELECT     MO.{0}, MO.{14}, MO.{1}, MO.{2}, MO.{15}, " +
            "           MO.{16}, MO.{17}, {13} = MOTM.{10} " +
            "FROM       {5} AS MOTM " +
            "INNER JOIN {6} AS MO ON MOTM.{7} = MO.{8} " +
            "INNER JOIN {9} AS MOT ON MOTM.{10} = MOT.{11} " +
            "WHERE      MOT.ManagedObjectTypeName LIKE '{12}' " +
            "AND        MO.{2} IS NULL",
                "ManagedObjectId",
                "ManagedObjectDisplayName",
                "InfrastructureConnectionId",
                "ManagedObjectTypeId",
                "ManagedObjectTypeName",
                "T_ManagedObjectToManagedObjectTypeMap",
                "T_ManagedObjects",
                "ManagedObjectId",
                "ManagedObjectId",
                "T_ManagedObjectTypes",
                "ManagedObjectTypeId",
                "ManagedObjectTypeId",
                "Framework.Root",
                "ManagedObjectTypeIds",
                "ManagedObjectName",
                "IsManualObject",
                "IsObjectMissing",
                "InMaintenanceMode");

            return query;
        }

        internal static String GetChildNodes()
        {
            String query = String.Format(
                "SELECT     MOH.{0} AS {6}, MO.{1}, MO.{2}, {8} = {9}({0}), " +
                "           MO.{12}, MOH.{10}, MO.{13}, MO.{14}, MO.{15} " +
                "FROM       {3} MOH " +
                "INNER JOIN {4} MO ON MOH.{0} = MO.{6} " +
                "WHERE      MOH.{5} = {7} " +
                "AND        MOH.{10} = {11} " +
                "ORDER BY   {1};",
                SqlConstants.Framework.ManagedObjectHierarchy.ChildId,
                SqlConstants.Framework.ManagedObjects.DisplayName,
                SqlConstants.Framework.ManagedObjects.InfrastructureConnectionId,
                SqlConstants.Framework.ManagedObjectHierarchy.TableName,
                SqlConstants.Framework.ManagedObjects.TableName,
                SqlConstants.Framework.ManagedObjectHierarchy.Id,
                SqlConstants.Framework.ManagedObjects.Id,
                1,
                SqlConstants.Framework.UserFunctions.GetManagedObjectTypeIds.
                ReturnParameterName,
                SqlConstants.Framework.UserFunctions.GetManagedObjectTypeIds.FunctionName,
                SqlConstants.Framework.ManagedObjectHierarchy.HierarchyViewMode,
                3,
                SqlConstants.Framework.ManagedObjects.Name,
                SqlConstants.Framework.ManagedObjects.IsManualObject,
                SqlConstants.Framework.ManagedObjects.IsObjectMissing,
                SqlConstants.Framework.ManagedObjects.InMaintenanceMode);


            return query;
        }
    }
}
