﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingLibrary.UI.DTOs
{
    public class BulkImportDTO
    {
        public Guid BookId { get; set; }

        public int Number { get; set; }
    }
}