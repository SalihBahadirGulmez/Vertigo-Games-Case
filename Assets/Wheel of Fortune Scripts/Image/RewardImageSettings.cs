using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;


namespace WheelOfFortune.Images.Reward
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Image/Reward Image Settings")]

    public class RewardImageSettings : ScriptableObject
    {
        [SerializeField] private List<float> _bombImageSizes = new List<float>() { 512, 512, 0.34f, 0.34f, 275, 0 };
        [SerializeField] internal List<float> _imageSizesSquare = new List<float>() { 512, 512, 0.17f, 0.17f, 275, 0 };
        [SerializeField] internal List<float> _imageSizes720_240 = new List<float>() { 720, 240, 0.21f, 0.21f, 270, 0 };
        [SerializeField] internal List<float> _imageSizes400_225 = new List<float>() { 400, 225, 0.34f, 0.34f, 270, 0 };
        [SerializeField] internal List<float> _imageSizes328_172 = new List<float>() { 328, 172, 0.4f, 0.4f, 270, 0 };
        [SerializeField] internal List<float> _imageSizes512_227 = new List<float>() { 512, 227, 0.26f, 0.26f, 270, 0 };

        internal List<List<float>> _allImageSizes = new List<List<float>>();

        internal string[] _squareSpecificNames = { "ui_icon_aviator_glasses_easter", "ui_icon_baseball_cap_easter", "ui_icon_helmet_pumpkin" };
        [SerializeField] internal float[] _squareSpecificSizes = { 0.3f, 0.2f, 0.15f };

        private ImageSize _spinSlotImageSizeSquare;
        private ImageSize _spinSlotImageSize720_240;
        private ImageSize _spinSlotImageSize400_225;
        private ImageSize _spinSlotImageSize328_172;
        private ImageSize _spinSlotImageSize512_227;
        internal RewardData _bombImage;
        internal ImageSize[] _allSpinSlotImageSizes;

        [SerializeField] private List<SpriteAtlas> _spriteAtlasesSquare;
        [SerializeField] private List<SpriteAtlas> _spriteAtlases720_240;
        [SerializeField] private List<SpriteAtlas> _spriteAtlases400_225;
        [SerializeField] private List<SpriteAtlas> _spriteAtlases328_172;
        [SerializeField] private List<SpriteAtlas> _spriteAtlases512_227;
        [SerializeField] private SpriteAtlas _spriteAtlasBomb;

        internal List<List<SpriteAtlas>> _allSpriteAtlases = new List<List<SpriteAtlas>>();

        internal List<string> _spriteAtlasSquareTier1Names = new List<string>()
        {
            "ui_icon_aviator_glasses_easter",
            "ui_icon_render_cons_grenade_m26",
            "ui_icon_render_cons_healthshot_2_neurostim",
            "UI_Icons_Armor_Points",
            "UI_Icons_Knife_Points",
            "UI_Icons_Pistol_Points",
            "UI_Icons_Pistol_Points_",
            "UI_Icons_Rifle_Points",
            "UI_Icons_Shotgun_Points",
            "UI_Icons_SMG_Points",
            "UI_Icons_Sniper_Points",
            "UI_Icons_Submachine_Points",
            "UI_Icons_Vest_Points"
        };
        internal List<string> _spriteAtlasSquareTier2Names = new List<string>()
        {
            "ui_icon_baseball_cap_easter",
            "ui_icon_render_cons_grenade_m67",
            "ui_icon_render_cons_healthshot_2_regenerator",
            "ui_icon_render_t_cons_molotov"
        };
        internal List<string> _spriteAtlasSquareTier3Names = new List<string>()
        {
            "ui_icon_helmet_pumpkin"
        };
        internal List<string> _spriteAtlas720_240Tier1Names = new List<string>()
        {
            "UI_Icon_Renders_tier1_shotgun"
        };
        internal List<string> _spriteAtlas720_240Tier2Names = new List<string>()
        {
            "UI_Icon_Renders_tier2_mle",
            "UI_Icon_Renders_tier2_rifle",
            "ui_icon_mle_bayonet_easter_time"
        };
        internal List<string> _spriteAtlas720_240Tier3Names = new List<string>()
        {
            "ui_icon_mle_bayonet_summer_vice",
            "UI_Icon_Renders_tier3_shotgun",
            "UI_Icon_Renders_tier3_smg",
            "UI_Icon_Renders_tier3_sniper"
        };
        internal List<string> _spriteAtlas400_225Tier1Names = new List<string>()
        {
            "UI_icon_gold"
        };
        internal List<string> _spriteAtlas328_172Tier1Names = new List<string>()
        {
            "UI_icon_cash"
        };
        internal List<string> _spriteAtlas512_227Tier1Names = new List<string>()
        {
            "UI_icon_chest_Bronze_nolight",
            "UI_icon_chest_small_noligt"
        };
        internal List<string> _spriteAtlas512_227Tier2Names = new List<string>()
        {
            "UI_icon_chest_silver_nolight",
            "UI_icon_chest_standart_nolight",
            "UI_icon_chest_big_nolight"
        };
        internal List<string> _spriteAtlas512_227Tier3Names = new List<string>()
        {
            "UI_icon_chest_gold_nolight",
            "UI_icon_chest_super_nolight"
        };

        internal List<List<string>> _spriteAtlasSquareAllTiers = new List<List<string>>();
        internal List<List<string>> _spriteAtlas720_240AllTiers = new List<List<string>>();
        internal List<List<string>> _spriteAtlas400_225AllTiers = new List<List<string>>();
        internal List<List<string>> _spriteAtlas328_172AllTiers = new List<List<string>>();
        internal List<List<string>> _spriteAtlas512_227AllTiers = new List<List<string>>();

        internal List<List<List<string>>> _allSpriteAtlasNames = new List<List<List<string>>>();
        internal void SetValues()
        {
            _allImageSizes.Add(_imageSizesSquare);
            _allImageSizes.Add(_imageSizes720_240);
            _allImageSizes.Add(_imageSizes400_225);
            _allImageSizes.Add(_imageSizes328_172);
            _allImageSizes.Add(_imageSizes512_227);

            _spinSlotImageSizeSquare = new ImageSize(_imageSizesSquare);
            _spinSlotImageSize720_240 = new ImageSize(_imageSizes720_240);
            _spinSlotImageSize400_225 = new ImageSize(_imageSizes400_225);
            _spinSlotImageSize328_172 = new ImageSize(_imageSizes328_172);
            _spinSlotImageSize512_227 = new ImageSize(_imageSizes512_227);
            _bombImage = new RewardData("ui_card_icon_death", 0, 0, 0, _bombImageSizes);
            _bombImage.SpriteAtlas = _spriteAtlasBomb;

            _allSpinSlotImageSizes = new ImageSize[5];
            _allSpinSlotImageSizes[0] = _spinSlotImageSizeSquare;
            _allSpinSlotImageSizes[1] = _spinSlotImageSize720_240;
            _allSpinSlotImageSizes[2] = _spinSlotImageSize400_225;
            _allSpinSlotImageSizes[3] = _spinSlotImageSize328_172;
            _allSpinSlotImageSizes[4] = _spinSlotImageSize512_227;

            _allSpriteAtlases.Add(_spriteAtlasesSquare);
            _allSpriteAtlases.Add(_spriteAtlases720_240);
            _allSpriteAtlases.Add(_spriteAtlases400_225);
            _allSpriteAtlases.Add(_spriteAtlases328_172);
            _allSpriteAtlases.Add(_spriteAtlases512_227);

            _spriteAtlasSquareAllTiers.Add(_spriteAtlasSquareTier1Names);
            _spriteAtlasSquareAllTiers.Add(_spriteAtlasSquareTier2Names);
            _spriteAtlasSquareAllTiers.Add(_spriteAtlasSquareTier3Names);
            _spriteAtlas720_240AllTiers.Add(_spriteAtlas720_240Tier1Names);
            _spriteAtlas720_240AllTiers.Add(_spriteAtlas720_240Tier2Names);
            _spriteAtlas720_240AllTiers.Add(_spriteAtlas720_240Tier3Names);
            _spriteAtlas400_225AllTiers.Add(_spriteAtlas400_225Tier1Names);
            _spriteAtlas328_172AllTiers.Add(_spriteAtlas328_172Tier1Names);
            _spriteAtlas512_227AllTiers.Add(_spriteAtlas512_227Tier1Names);
            _spriteAtlas512_227AllTiers.Add(_spriteAtlas512_227Tier2Names);
            _spriteAtlas512_227AllTiers.Add(_spriteAtlas512_227Tier3Names);

            _allSpriteAtlasNames.Add(_spriteAtlasSquareAllTiers);
            _allSpriteAtlasNames.Add(_spriteAtlas720_240AllTiers);
            _allSpriteAtlasNames.Add(_spriteAtlas400_225AllTiers);
            _allSpriteAtlasNames.Add(_spriteAtlas328_172AllTiers);
            _allSpriteAtlasNames.Add(_spriteAtlas512_227AllTiers);
        }
    }

    public class ImageSize
    {
        private float _width;
        private float _height;
        private float _scaleX;
        private float _scaleY;
        private float _posY;
        private float _posX;

        public float Width { get { return _width; } }
        public float Height { get { return _height; } }
        public float ScaleX { get { return _scaleX; } set { _scaleX = value; } }
        public float ScaleY { get { return _scaleY; } set { _scaleY = value; } }
        public float PosY { get { return _posY; } }
        public float PosX { get { return _posX; } }
        public ImageSize(float width, float height, float scaleX, float scaleY, float posY, float posX)
        {
            _width = width;
            _height = height;
            _scaleX = scaleX;
            _scaleY = scaleY;
            _posY = posY;
            _posX = posX;
        }
        public ImageSize(List<float> imageTransform)
        {
            _width = imageTransform[0];
            _height = imageTransform[1];
            _scaleX = imageTransform[2];
            _scaleY = imageTransform[3];
            _posY = imageTransform[4];
            _posX = imageTransform[5];
        }

    }

    public class RewardData : ImageSize
    {
        private string _name;
        private int _quantity;
        private int _atlasSizeNum;
        private int _atlasTierNum;
        private int _atlasNameNum;
        private SpriteAtlas _spriteAtlas;
        private GameObject _imageGameObject;
        private GameObject _textGameObject;

        public string Name { get { return _name; } }
        public int AtlasSizeNum { get { return _atlasSizeNum; } }
        public int AtlasTierNum { get { return _atlasTierNum; } }
        public int AtlasNameNum { get { return _atlasNameNum; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        public SpriteAtlas SpriteAtlas { get { return _spriteAtlas; } set { _spriteAtlas = value; } }
        public GameObject ImageGameObject { get { return _imageGameObject; } set { _imageGameObject = value; } }
        public GameObject TextGameObject { get { return _textGameObject; } set { _textGameObject = value; } }
        public RewardData(string name, int atlasSizeNum, int atlasTierNum, int atlasNameNum, List<float> imageSizeData) : base(imageSizeData)
        {
            _name = name;
            _atlasSizeNum = atlasSizeNum;
            _atlasTierNum = atlasTierNum;
            _atlasNameNum = atlasNameNum;
        }
    }

}