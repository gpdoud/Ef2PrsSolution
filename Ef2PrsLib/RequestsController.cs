using Ef2PrsConsole;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ef2PrsLib {

    public class RequestsController {

        private readonly prs0Context _context;

        public RequestsController(prs0Context context) {
            _context = context;
        }

        public List<Request> GetRequestsInReview() {
            return _context.Requests.Where(r => r.Status == "REVIEW").ToList();
        }

        public bool RecalculateRequestTotal(int Id) {
            var request = _context.Requests.Find(Id);
            var reqTotal = (from li in _context.Lineitems.ToList()
                            join pr in _context.Products.ToList()
                            on li.ProductId equals pr.Id
                            where li.RequestId == Id
                            select new {
                                LineTotal = li.Quantity * pr.Price
                            }).Sum(t => t.LineTotal);
            request.Total = reqTotal;
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Reviews the request for the owner(user)
        /// Status is set to APPROVED if Total <= 50
        /// else status is set to REVIEW
        /// </summary>
        /// <param name="request">A request</param>
        /// <returns>True if successful; else false</returns>
        public bool ReviewRequest(Request request) {
            //if(request.Total <= 50) {
            //    request.Status = "APPROVED";
            //} else {
            //    request.Status = "REVIEW";
            //}
            request.Status = (request.Total <= 50) ? "APPROVED" : "REVIEW";
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Sets the status of the request to REJECTED
        /// </summary>
        /// <param name="request">A single request</param>
        /// <returns>True if successful; else false</returns>
        public bool SetToRejected(Request request) {
            request.Status = "REJECTED";
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Sets the status of the request to APPROVED
        /// </summary>
        /// <param name="request">A single request</param>
        /// <returns>True if successful; else false</returns>
        public bool SetToApproved(Request request) {
            request.Status = "APPROVED";
            _context.SaveChanges();
            return true;
        }
    }
}
