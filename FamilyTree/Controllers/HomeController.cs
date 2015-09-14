using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyTree.Models;

namespace FamilyTree.Controllers
{
    public class HomeController : Controller
    {
        Models.DatabaseEntities db = new Models.DatabaseEntities();

        public ActionResult Index()
        {
            Trees trees = new Trees();
            trees.read = db.Set<Tree>();
            return View(trees);
        }

        [HttpPost]
        public ActionResult addTree(FamilyTree.Models.Trees model)
        {
            db.Trees.Add(model.add);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Tree(string Id)
        {
            TreeWrapper wrapper = new TreeWrapper();
            wrapper.tree = db.Trees.Where(x => x.TreeName == Id).ToList()[0];
            wrapper.nodes = db.Nodes.Where(y => y.TreeId == wrapper.tree.Id).ToList();
            return View(wrapper);
        }


        [HttpPost]
        public ActionResult addNode(FamilyTree.Models.Node node)
        {
            if (node.Mother == "None")
            {
                node.Mother = null;
            }
            if (node.Father == "None")
            {
                node.Father = null;
            }
            db.Nodes.Add(node);
            db.SaveChanges();
            string treeName = db.Trees.Where(x => x.Id == node.TreeId).ToList()[0].TreeName;
            return RedirectToAction("Tree", new { Id = treeName });
        }

    }
}