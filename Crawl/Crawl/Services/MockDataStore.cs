using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawl.Models;
using Crawl.ViewModels;

namespace Crawl.Services
{
    public sealed class MockDataStore : IDataStore
    {

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static MockDataStore _instance;

        public static MockDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MockDataStore();
                }
                return _instance;
            }
        }

        private List<Item> _itemDataset = new List<Item>();
        private List<Character> _characterDataset = new List<Character>();
        private List<Monster> _monsterDataset = new List<Monster>();
        private List<Score> _scoreDataset = new List<Score>();

        private MockDataStore()
        {
            InitilizeSeedData();
        }

        private void InitilizeSeedData()
        {

            // Implement

            // Load Items.


            String Katana_IMG = "https://b.kisscc0.com/20180706/ge/kisscc0-japanese-sword-katana-samurai-wakisashi-5b3f429ac0aca9.0869634215308724747892.png";
            String Helmet_IMG = "http://png.clipart-library.com/images/3/halo-master-chief-helmet-clip-art/master-chief-halo-combat-evolved-halo-4-helmet-ha-it-s-snowing-5adf4f57a43326.2259542015245842796726.jpg";
            String Glasses_IMG = "https://b.kisscc0.com/20180814/ljq/kisscc0-sunglasses-eyewear-drawing-eyeglasses-2-5b73257b53bac3.423023741534272891343.png";
            String Sheild_IMG = "https://i5.walmartimages.com/asr/4c0b5887-464b-44f3-9a9a-5c578c71f70d_1.61fa9108898ea9a76ba573181ed9883b.jpeg";
            String Dagger_IMG = "https://www.darksword-armory.com/wp-content/uploads/2014/09/ranger-medieval-lord-of-the-rings-dagger-1800.jpg";

            _itemDataset.Add(new Item("Katana", "An ancient blade.",
                Katana_IMG, 0, 10, 10, ItemLocationEnum.PrimaryHand, AttributeEnum.Defense));

            _itemDataset.Add(new Item("Hylian Shield", "The sheild of a hero...",
                Sheild_IMG, 0, 10, 0, ItemLocationEnum.OffHand, AttributeEnum.Defense));

            _itemDataset.Add(new Item("Helmet", "The mask of a warrior.",
                Helmet_IMG, 0, 20, 0, ItemLocationEnum.Head, AttributeEnum.Defense));

            _itemDataset.Add(new Item("Glasses", "Not stylish, but very effective.",
                Glasses_IMG, 0, 10, 0, ItemLocationEnum.Head, AttributeEnum.Speed));

            _itemDataset.Add(new Item("Dagger", "A nimble blade.",
                Dagger_IMG, 2, 5, 10, ItemLocationEnum.Head, AttributeEnum.Speed));
            // Implement Characters

            // Implement Monsters

            // Implement Scores
        }

        private void CreateTables()
        {
            // Do nothing...
        }

        // Delete the Datbase Tables by dropping them
        public void DeleteTables()
        {
            // Implement
        }

        // Tells the View Models to update themselves.
        private void NotifyViewModelsOfDataChange()
        {
            ItemsViewModel.Instance.SetNeedsRefresh(true);
            // Implement Monsters

            // Implement Characters 

            // Implement Scores
        }

        public void InitializeDatabaseNewTables()
        {
            DeleteTables();

            // make them again
            CreateTables();

            // Populate them
            InitilizeSeedData();

            // Tell View Models they need to refresh
            NotifyViewModelsOfDataChange();
        }

        #region Item
        // Item
        public async Task<bool> InsertUpdateAsync_Item(Item data)
        {

            // Check to see if the item exist
            var oldData = await GetAsync_Item(data.Id);
            if (oldData == null)
            {
                _itemDataset.Add(data);
                return true;
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Item(data);
            if (UpdateResult)
            {
                await AddAsync_Item(data);
                return true;
            }

            return false;
        }

        public async Task<bool> AddAsync_Item(Item data)
        {
            _itemDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            var myData = _itemDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            var myData = _itemDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _itemDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            return await Task.FromResult(_itemDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            return await Task.FromResult(_itemDataset);
        }

        #endregion Item

        #region Character
        // Character
        public async Task<bool> AddAsync_Character(Character data)
        {
            // Implement
            return false;
        }

        public async Task<bool> UpdateAsync_Character(Character data)
        {
            // Implement
            return false;
        }

        public async Task<bool> DeleteAsync_Character(Character data)
        {
            // Implement
            return false;
        }

        public async Task<Character> GetAsync_Character(string id)
        {
            // Implement
            return null;
        }

        public async Task<IEnumerable<Character>> GetAllAsync_Character(bool forceRefresh = false)
        {
            // Implement
            return null;
        }

        #endregion Character

        #region Monster
        //Monster
        public async Task<bool> AddAsync_Monster(Monster data)
        {
            // Implement
            return false;
        }

        public async Task<bool> UpdateAsync_Monster(Monster data)
        {
            // Implement
            return false;
        }

        public async Task<bool> DeleteAsync_Monster(Monster data)
        {
            // Implement
            return false;
        }

        public async Task<Monster> GetAsync_Monster(string id)
        {
            // Implement
            return null;
        }

        public async Task<IEnumerable<Monster>> GetAllAsync_Monster(bool forceRefresh = false)
        {
            // Implement
            return null;
        }

        #endregion Monster

        #region Score
        // Score
        public async Task<bool> AddAsync_Score(Score data)
        {
            // Implement
            return false;
        }

        public async Task<bool> UpdateAsync_Score(Score data)
        {
            // Implement
            return false;
        }

        public async Task<bool> DeleteAsync_Score(Score data)
        {
            // Implement
            return false;
        }

            public async Task<Score> GetAsync_Score(string id)
        {
            // Implement
            return null;
        }

        public async Task<IEnumerable<Score>> GetAllAsync_Score(bool forceRefresh = false)
        {
            // Implement
            return null;
        }
        #endregion Score
    }
}