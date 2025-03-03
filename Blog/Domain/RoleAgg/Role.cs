﻿ using Common.Domain;
using Common.Domain.Exceptions;

namespace Blog.Domain.RoleAgg
{
    public class Role : AggregateRoot
    {
        public string Title { get; private set; }
        public List<RolePermission> Permissions { get; private set; }

        private Role()
        {
        }

        public Role(string title, List<RolePermission> permissions)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));

            Title = title;
            Permissions = permissions;
        }

        public Role(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));

            Title = title;
            Permissions = new List<RolePermission>();
        }

        public void Edit(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            Title = title;
        }

        //public void SetPermissions(List<RolePermission> permissions)
        //{
        //   var RolePermission = new List<RolePermission>();
        //    foreach (var item in permissions)
        //    {
        //          var permission = new RolePermission();

        //          Permissions = permissions;
        //    }

        //}
        public void SetPermissions(List<RolePermission> permissions)
        {

            Permissions = permissions;
        }
    }
}