﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class RepComment : BaseAuditableEntity
{
    [ForeignKey("UserAccount")]
    public Guid UserAccountId { get; set; }
    [ForeignKey("Comment")]
    public Guid CommentId { get; set; }
    public IList<ManagerAccount>? ManagerAccounts { get; private set; }
}
