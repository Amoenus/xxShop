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

namespace YSWL.Json
{
    #region Imports

    using System;

    #endregion
    
    /// <summary>
    /// Base implementation of <see cref="JsonReader"/> that can be used
    /// as a starting point for sub-classes of <see cref="JsonReader"/>.
    /// </summary>

    public abstract class JsonReaderBase : JsonReader
    {
        private JsonToken _token;
        private int _depth;
        private int _maxDepth = 100;

        protected JsonReaderBase()
        {
            _token = JsonToken.BOF();
        }

        /// <summary>
        /// Gets the current token.
        /// </summary>

        public sealed override JsonToken Token
        {
            get { return _token; }
        }

        /// <summary>
        /// Return the current level of nesting as the reader encounters
        /// nested objects and arrays.
        /// </summary>

        public sealed override int Depth
        {
            get { return _depth; }
        }

        /// <summary>
        /// Sets or returns the maximum allowed depth or level of nestings
        /// of objects and arrays.
        /// </summary>

        public sealed override int MaxDepth
        {
            get { return _maxDepth; }
            set { _maxDepth = value; }
        }

        /// <summary>
        /// Reads the next token and returns true if one was found.
        /// </summary>

        public sealed override bool Read()
        {
            if (!EOF)
            {
                if (Depth > MaxDepth)
                    throw new Exception("Maximum allowed depth has been exceeded.");

                if (TokenClass == JsonTokenClass.EndObject || TokenClass == JsonTokenClass.EndArray)
                    _depth--;

                _token = ReadTokenImpl();

                if (TokenClass == JsonTokenClass.Object || TokenClass == JsonTokenClass.Array)
                    _depth++;
            }
            
            return !EOF;
        }

        /// <summary>
        /// Reads the next token and returns it.
        /// </summary>
        
        protected abstract JsonToken ReadTokenImpl();
    }
}