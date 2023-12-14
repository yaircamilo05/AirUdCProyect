using System.Net;
using System.Web.Mvc;
using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirbnbUdC.Application.Implementation.Implementation.Manager;
using AirUdC.GUI.Mappers.Manager;
using AirUdC.GUI.Models.Manager;

namespace AirUdC.GUI.Controllers.Manager
{
    public class CustomerController : Controller
    {
        private readonly ICustomerApplication _app;
        private readonly CustomerMapperGUI _customerMapper;

        public CustomerController(ICustomerApplication app)
        {
            _app = app;
            _customerMapper = new CustomerMapperGUI();
        }

        // GET: Customer
        public ActionResult Index(string filter = "")
        {
            var records = _app.GetAllRecords(filter);
            var mapped = _customerMapper.MapListT1toT2(records);
            return View(mapped);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _app.GetRecord(id);
            CustomerModel customerModel = _customerMapper.MapT1toT2(customer);
            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(customerModel);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,FamilyName,Email,Cellphone,Photo")] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                _app.CreateRecord(_customerMapper.MapT2toT1(customerModel));
                return RedirectToAction("Index");
            }

            return View(customerModel);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customerModel = _customerMapper.MapT1toT2(_app.GetRecord(id));
            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(customerModel);
        }

        // POST: Customer/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,FamilyName,Email,Cellphone,Photo")] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                _app.UpdateRecord(_customerMapper.MapT2toT1(customerModel));
                return RedirectToAction("Index");
            }
            return View(customerModel);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customerModel = _customerMapper.MapT1toT2(_app.GetRecord(id));
            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(customerModel);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _app.DeleteRecord(id);
            return RedirectToAction("Index");
        }
    }
}
