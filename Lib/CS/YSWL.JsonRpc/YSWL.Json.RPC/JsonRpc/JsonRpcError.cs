#region License, Terms and Conditions
//
// YSWL - JSON and JSON-RPC for Microsoft .NET Framework and Mono
//
// Copyright (c) 2006-2012 YS56. All Rights Reserved.
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 3 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
// details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library; if not, write to the Free Software Foundation, Inc.,
// 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
//
#endregion

namespace YSWL.Json.RPC
{
    #region Imports

    using System;
    using System.Diagnostics;
    using YSWL.Json;

    #endregion

    public sealed class JsonRpcError
    {
        public static JsonObject FromException(Exception e)
        {
            return FromException(e, false);
        }

        public static JsonObject FromException(Exception e, bool includeStackTrace)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            JsonObject error = new JsonObject();
            error.Put("name", "JSONRPCError");
            error.Put("message", e.GetBaseException().Message);

            if (includeStackTrace)
                error.Put("stackTrace", e.StackTrace);

            JsonArray errors = new JsonArray();
                
            do
            {
                errors.Put(ToLocalError(e));
                e = e.InnerException;
            }
            while (e != null);
            
            error.Put("errors", errors);
            
            return error;
        }

        private static JsonObject ToLocalError(Exception e) 
        {
            Debug.Assert(e != null);
            
            JsonObject error = new JsonObject();
            
            error.Put("name", e.GetType().Name);
            error.Put("message", e.Message);
            
            return error;
        }

        private JsonRpcError()
        {
            throw new NotSupportedException();
        }
    }
}
