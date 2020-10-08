using Ef2PrsLib;

using System;
using System.Linq;

namespace Ef2PrsConsole {
    class Program {
        static void Main(string[] args) {

            var _context = new prs0Context();

            var ReqCtrl = new RequestsController(_context);
            var updTotal = ReqCtrl.RecalculateRequestTotal(1);

            var req1 = _context.Requests.Find(1);
            var ok = ReqCtrl.ReviewRequest(req1);
            var req3 = _context.Requests.Find(3);
            ok = ReqCtrl.ReviewRequest(req3);

            var req2 = _context.Requests.Find(2);
            var isWorked = ReqCtrl.SetToApproved(req2);

            var UserCtrl = new UsersController(_context);
            // Tests the login functio
            var yyuser = UserCtrl.Login("yy", "yy");
            var sauser = UserCtrl.Login("sa", "sa");
        }
    }
}
