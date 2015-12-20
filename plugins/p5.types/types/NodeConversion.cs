/*
 * Phosphorus Five, copyright 2014 - 2015, Thomas Hansen, phosphorusfive@gmail.com
 * Phosphorus Five is licensed under the terms of the MIT license, see the enclosed LICENSE file for details
 */

using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;
using p5.exp;
using p5.core;
using p5.exp.exceptions;

namespace p5.types.types
{
    /// <summary>
    ///     Class helps converts from node to string, and vice versa
    /// </summary>
    public static class NodeConversion
    {
        /// <summary>
        ///     Creates a <see cref="phosphorus.core.Node">Node</see> list from its string representation
        /// </summary>
        /// <param name="context">Application Context</param>
        /// <param name="e">Parameters passed into Active Event</param>
        [ActiveEvent (Name = "p5.hyperlisp.get-object-value.node", Protection = EventProtection.NativeClosed)]
        private static void p5_hyperlisp_get_object_value_node (ApplicationContext context, ActiveEventArgs e)
        {
            var code = e.Args.Get<string> (context);
            var tmp = new Node ("", code);
            context.RaiseNative ("lisp2lambda", tmp);
            e.Args.Value = tmp.Children.Count > 0 ? new Node ("", null, tmp.Children) : null;
        }

        /// <summary>
        ///     Creates a single <see cref="phosphorus.core.Node">Node</see> from its string representation
        /// </summary>
        /// <param name="context">Application Context</param>
        /// <param name="e">Parameters passed into Active Event</param>
        [ActiveEvent (Name = "p5.hyperlisp.get-object-value.abs.node", Protection = EventProtection.NativeClosed)]
        private static void p5_hyperlisp_get_object_value_abs_node (ApplicationContext context, ActiveEventArgs e)
        {
            var code = e.Args.Get<string> (context);
            var tmp = new Node ("", code);
            context.RaiseNative ("lisp2lambda", tmp);

            // Different logic if there's one node or multiple nodes!
            if (tmp.Children.Count == 1) {

                // If there's only one node, we return that as result
                e.Args.Value = tmp [0];
            } else if (tmp.Children.Count > 1) {

                // Oops, error!
                throw new LambdaException (
                    "Cannot convert string to 'abs' Node, since it would create more than one resulting root node",
                    e.Args, 
                    context);
            } else {

                // No result!
                e.Args.Value = null;
            }
        }

        /// <summary>
        ///     Creates a string from a <see cref="phosphorus.core.Node">Node</see>
        /// </summary>
        /// <param name="context">Application Context</param>
        /// <param name="e">Parameters passed into Active Event</param>
        [ActiveEvent (Name = "p5.hyperlisp.get-string-value.p5.core.Node", Protection = EventProtection.NativeClosed)]
        private static void p5_hyperlisp_get_string_value_p5_core_Node (ApplicationContext context, ActiveEventArgs e)
        {
            var tmp = new Node ("", e.Args.Value);
            context.RaiseNative ("lambda2lisp", tmp);
            e.Args.Value = tmp.Value;
        }

        /// <summary>
        ///     Returns the Hyperlisp type-name for the <see cref="phosphorus.core.Node">Node</see> type
        /// </summary>
        /// <param name="context">Application Context</param>
        /// <param name="e">Parameters passed into Active Event</param>
        [ActiveEvent (Name = "p5.hyperlisp.get-type-name.p5.core.Node", Protection = EventProtection.NativeClosed)]
        private static void p5_hyperlisp_get_type_name_p5_core_Node (ApplicationContext context, ActiveEventArgs e)
        {
            e.Args.Value = "node";
        }
    }
}
