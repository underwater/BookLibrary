﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingLibrary.UI.DTOs
{
    public class ImportBookInventoryDTO
    {
        public ImportBookInventoryDTO()
        {
            BookInventoryIds = new List<Guid>();
        }

        public List<Guid> BookInventoryIds { get; set; }
    }
}