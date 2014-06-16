﻿//////////////////////////////////////////////////////////////////////////////////
//  Managed UPnP
//	Written by Aaron Lee Murgatroyd (http://home.exetel.com.au/amurgshere/)
//	A CodePlex project (http://managedupnp.codeplex.com/)
//  Released under the Microsoft Public License (Ms-PL) .
//////////////////////////////////////////////////////////////////////////////////

#if !Exclude_Descriptions || !Exclude_CodeGen

using System;
using System.Text;
using System.Xml;

namespace ManagedUPnP.Descriptions
{
    /// <summary>
    /// Encapsulates a description list with built in ToString formatting.
    /// </summary>
    /// <typeparam name="T">The stored list value type.</typeparam>
    public abstract class FormattedDescriptionList<T> : 
        DescriptionList<T> where T : Description
    {
        #region Initialisation

        /// <summary>
        /// Creates a new formatted description list.
        /// </summary>
        /// <param name="parent">The parent description object, or null if root description.</param>
        public FormattedDescriptionList(Description parent)
            : base(parent)
        {
        }

        /// <summary>
        /// Creates a new formatted description list from a reader.
        /// </summary>
        /// <param name="parent">The parent description object, or null if root description.</param>
        /// <param name="reader">The XML reader.</param>
        public FormattedDescriptionList(Description parent, XmlTextReader reader)
            : base(parent, reader)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Converts the description to a string.
        /// </summary>
        /// <param name="indent">The indent for the string.</param>
        /// <returns>The string representation for the description.</returns>
        public override string ToString(int indent)
        {
            if (this.Count > 0)
            {
                string lsIndent = Indent(indent);
                StringBuilder lsbBuilder = new StringBuilder();

                lsbBuilder.Append(lsIndent);
                lsbBuilder.AppendLine("{");

                foreach (Description ldDesc in this)
                    lsbBuilder.AppendLine(ldDesc.ToString(indent + 1));

                lsbBuilder.Append(lsIndent);
                lsbBuilder.Append("}");

                lsbBuilder.Append(base.ToString(indent).LineBefore());

                return lsbBuilder.ToString();
            }
            else
                return String.Empty;
        }

        #endregion
    }
}

#endif