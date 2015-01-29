
/*
 * phosphorus five, copyright 2014 - Mother Earth, Jannah, Gaia
 * phosphorus five is licensed as mitx11, see the enclosed LICENSE file for details
 */

using System;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Globalization;
using System.Security.Cryptography;
using phosphorus.core;
using phosphorus.lambda;
using phosphorus.ajax.widgets;

namespace phosphorus.web
{
    /// <summary>
    /// helper to retrieve and set session values
    /// </summary>
    public static class session
    {
        /// <summary>
        /// sets the given session key to the nodes given as children of [pf.web.session.set]. if no nodes are given,
        /// the session with the given key is cleared
        /// </summary>
        /// <param name="context"><see cref="phosphorus.Core.ApplicationContext"/> for Active Event</param>
        /// <param name="e">parameters passed into Active Event</param>
        [ActiveEvent (Name = "pf.web.session.set")]
        private static void pf_web_session_set (ApplicationContext context, ActiveEventArgs e)
        {
            string key = e.Args.Get<string> ();
            if (Expression.IsExpression (key)) {
                var match = Expression.Create (key).Evaluate (e.Args);
                if (!match.IsSingleLiteral || match.TypeOfMatch == Match.MatchType.Count || match.TypeOfMatch == Match.MatchType.Path) {
                    throw new ArgumentException ("expression for [pf.web.session.set] must be an expression returning on value of type 'value' or 'name'");
                }
                key = match.GetValue (0) as string;
                if (string.IsNullOrEmpty (key)) {
                    throw new ArgumentException ("expression value given to [pf.web.session.set] was null or empty");
                }
            }
            if (e.Args.Count > 0)
                HttpContext.Current.Session [key] = e.Args.Clone ();
            else
                HttpContext.Current.Session.Remove (key);
        }

        /// <summary>
        /// returns the session object given through the value of [pf.web.session.get] as a node
        /// </summary>
        /// <param name="context"><see cref="phosphorus.Core.ApplicationContext"/> for Active Event</param>
        /// <param name="e">parameters passed into Active Event</param>
        [ActiveEvent (Name = "pf.web.session.get")]
        private static void pf_web_session_get (ApplicationContext context, ActiveEventArgs e)
        {
            string key = e.Args.Get<string> ();
            if (Expression.IsExpression (key)) {
                var match = Expression.Create (key).Evaluate (e.Args);
                if (!match.IsSingleLiteral || match.TypeOfMatch == Match.MatchType.Count || match.TypeOfMatch == Match.MatchType.Path) {
                    throw new ArgumentException ("expression for [pf.web.session.get] must be an expression returning on value of type 'value' or 'name'");
                }
                key = match.GetValue (0) as string;
                if (string.IsNullOrEmpty (key)) {
                    throw new ArgumentException ("expression value given to [pf.web.session.get] was null or empty");
                }
            } else if (e.Args.Count > 0) {
                key = Expression.FormatNode (e.Args);
            }
            object tmp = HttpContext.Current.Session [key];
            if (tmp != null)
                e.Args.AddRange ((tmp as Node).Clone ().Children);
        }
    }
}