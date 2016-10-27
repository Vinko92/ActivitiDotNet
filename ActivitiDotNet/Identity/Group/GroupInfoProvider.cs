using System.Collections.Generic;

using ActivitiDotNet.Abstract;
using ActivitiDotNet.Constants;
using ActivitiDotNet.CustomModel;
using ActivitiDotNet.Helpers;
using ActivitiDotNet.Model;
using Newtonsoft.Json.Linq;

namespace ActivitiDotNet.User
{
    /// <summary>
    /// Contains all necessary methods for manipulation of Group class.
    /// </summary>
    public class GroupInfoProvider : BaseInfoProvider<GroupInfo>, IReadable<GroupInfo>, IWriteable<GroupInfo>, IRemoveable<GroupInfo>
    {
        public GroupInfoProvider() : base(UrlConstants.GROUP)
        {
        }

        /// <summary>
        /// Creates new group.
        /// </summary>
        /// <param name="value"><seealso cref="GroupInfo"/> object.</param>
        public new void Create(ref GroupInfo value)
        {
            base.Create(ref value);
        }

        /// <summary>
        /// Deletes existing group.
        /// </summary>
        /// <param name="id">Id of the group.</param>
        public new GroupInfo Delete(string id)
        {
            return base.Delete(id);
        }

        /// <summary>
        /// Gets existing group.
        /// </summary>
        /// <param name="id">Id of the group.</param>
        /// <returns><seealso cref="GroupInfo"/> object.</returns>
        public new GroupInfo Get(string id)
        {
            return base.Get(id);
        }

        /// <summary>
        /// Gets all existing groups.
        /// </summary>
        /// <returns><seealso cref="List{GroupInfo}"/> object.</returns>
        public new List<GroupInfo> GetAll()
        {
            return base.GetAll();
        }

        /// <summary>
        /// Tries to delete existing group.
        /// </summary>
        /// <param name="id">Id of the group.</param>
        /// <param name="value"><seealso cref="GroupInfo"/> object</param>
        /// <returns>Indicator if group is deleted.</returns>
        public new bool TryDelete(string id, out GroupInfo value)
        {
            return base.TryDelete(id, out value);
        }

        /// <summary>
        /// Updates existing group.
        /// </summary>
        /// <param name="id">Id of the group.</param>
        /// <param name="value">Value of the group to be updated.</param>
        /// <returns>Updated <seealso cref="GroupInfo"/> object</returns>
        public new GroupInfo Update(string id, GroupInfo value)
        {
            return base.Update(id, value);
        }

        /// <summary>
        /// Gets all members of the group.
        /// </summary>
        /// <param name="groupId">Id of the group.</param>
        /// <returns><seealso cref="List{UserInfo}"/> object.</returns>
        public List<UserInfo> GetMembers(string groupId)
        {
            string url = UrlBuilder.BuildUrl(UrlConstants.USER) + "?memberOfGroup=" + groupId;

            return BaseInfoProvider<List<UserInfo>>.ExecuteOperation(url, Network.HttpMethod.GET, "kermit", "kermit", jsonRoot: "data");
        }

        /// <summary>
        /// Add member to existing group.
        /// </summary>
        /// <param name="groupId">Id of the group.</param>
        /// <param name="userId">Id of the user.</param>
        /// <returns><seealso cref="UserInfo"/> object.</returns>
        public UserInfo AddMember(string groupId, string userId)
        {
            string url = UrlBuilder.BuildUrl(UrlConstants.GROUP, groupId, "members");

            JObject json = new JObject();
            json.Add("userId", userId);

            return BaseInfoProvider<UserInfo>.ExecuteOperation(url, Network.HttpMethod.POST, "kermit", "kermit", body: json.ToString());
        }

        /// <summary>
        /// Delete member from existing group.
        /// </summary>
        /// <param name="groupId">Id of the group.</param>
        /// <param name="userId">Id of the user.</param>
        public void DeleteMember(string groupId, string userId)
        {
            string url = UrlBuilder.BuildUrl(UrlConstants.GROUP, groupId, "members", userId);

            BaseInfoProvider<UserInfo>.ExecuteOperation(url, Network.HttpMethod.DELETE, "kermit", "kermit");
        }


    }
}
