﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class EntranceTest : BaseAuditableEntity
{
    public virtual IList<AnswersForEntranceTest>? AnswersForEntranceTest { get; set; }
}
