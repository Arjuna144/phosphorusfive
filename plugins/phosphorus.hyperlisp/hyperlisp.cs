
/*
 * phosphorus five, copyright 2014 - Mother Earth, Jannah, Gaia
 * phosphorus five is licensed as mit, see the enclosed LICENSE file for details
 */

using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using phosphorus.core;
using phosphorus.lambda;

namespace phosphorus.hyperlisp
{
    /// <summary>
    /// class to help transform between hyperlisp and <see cref="phosphorus.core.Node"/> 
    /// </summary>
    public static class hyperlisp
    {
        /// <summary>
        /// helper to transform from hyperlisp code syntax to <see cref="phosphorus.core.Node"/> tree structure.
        /// will transform the given hyperlisp into a list of nodes and append them into the root node given
        /// through the active event args
        /// </summary>
        /// <param name="context"><see cref="phosphorus.Core.ApplicationContext"/> for Active Event</param>
        /// <param name="e">parameters passed into Active Event</param>
        [ActiveEvent (Name = "pf.hyperlisp.hyperlisp2lambda")]
        private static void pf_hyperlisp_hyperlisp2lambda (ApplicationContext context, ActiveEventArgs e)
        {
            StringBuilder builder = new StringBuilder ();
            Expression.Iterate<string> (e.Args, true, 
            delegate (string idx) {
                builder.Append (idx + "\n");
            });
            e.Args.AddRange (new NodeBuilder (context, builder.ToString ()).Nodes);
        }

        /// <summary>
        /// helper to transform from <see cref="phosphorus.core.Node"/> tree structure to hyperlisp code syntax.
        /// will transform the children nodes of the given active event args into hyperlisp and return as string
        /// value of the value of the given active event args
        /// </summary>
        /// <param name="context"><see cref="phosphorus.Core.ApplicationContext"/> for Active Event</param>
        /// <param name="e">parameters passed into Active Event</param>
        [ActiveEvent (Name = "pf.hyperlisp.lambda2hyperlisp")]
        private static void pf_code_lambda2hyperlisp (ApplicationContext context, ActiveEventArgs e)
        {
            if (Expression.IsExpression (e.Args.Value)) {
                List<Node> nodeList = new List<Node> ();
                Expression.Iterate<Node> (e.Args, true, 
                delegate (Node idx) {
                    nodeList.Add (idx);
                });
                e.Args.Value = new HyperlispBuilder (context, nodeList).Hyperlisp;
            } else if (e.Args.Value is Node) {
                e.Args.Value = new HyperlispBuilder (context, new Node [] { e.Args.Get<Node> () }).Hyperlisp;
            } else {
                e.Args.Value = new HyperlispBuilder (context, e.Args.Children).Hyperlisp;
            }
        }
    }
}
