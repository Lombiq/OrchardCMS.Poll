﻿using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;

namespace Urbanit.Polls
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManagePollsPermission = new Permission
        {
            Category = "Management for Urbanit Polls module",
            Description = "Allow the management of polls.",
            Name = "PollsManagePermission"
        };

        public virtual Feature Feature { get; set; }


        public IEnumerable<Permission> GetPermissions()
        {
            return new[]
                   {
                       ManagePollsPermission,
                   };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
                   {
                       new PermissionStereotype
                       {
                           Name = "Administrator",
                           Permissions = new[] {ManagePollsPermission}
                       },
                       new PermissionStereotype
                       {
                           Name = "Editor",
                           Permissions = new[] {ManagePollsPermission}
                       },
                       new PermissionStereotype
                       {
                           Name = "Author",
                           Permissions = new[] {ManagePollsPermission}
                       },
                   };
        }
    }
}