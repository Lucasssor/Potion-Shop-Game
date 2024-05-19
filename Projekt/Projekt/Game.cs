using Projekt.Potions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projekt
{
    internal class Game
    {

        public IngredientShopScene MyIngredientShopScene;
        public IngredientShop MyIngredientShop;
        public TitleScene MyTitleScene;
        public NavigationScene MyNavigationScene;
        public AlchemistScene MyAlchemistScene;
        public ClientScene MyClientScene;
        public LabScene MyLabScene;

        public List<Recipe> Potions { get; } = new List<Recipe>();
      
        public Game()
        {      
            MyTitleScene = new TitleScene(this);
            MyIngredientShopScene = new IngredientShopScene(this);
            MyNavigationScene = new NavigationScene(this);
            MyAlchemistScene = new AlchemistScene(this);            
            MyClientScene = new ClientScene(this);
            MyLabScene = new LabScene(this);          
        }        
        public void Start()
        {
            MyTitleScene.Run();
  
        }
    }

}
