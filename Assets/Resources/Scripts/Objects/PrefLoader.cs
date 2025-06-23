using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class PrefLoader : MonoBehaviour
{
    /// Addressable 관련
    public List<GameObject> loadedPrefOffers = new List<GameObject>();
    public List<string> prefAddresses = new List<string> { "Offer" };

    private void Awake()
    {
        LoadBasicOfferPrefabs();
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    void LoadBasicOfferPrefabs()
    {
        // TODO: Addressables를 사용해서 로드하고 싶다
        Addressables.LoadAssetsAsync<GameObject>("OfferGroup", OnPrefabLoad).Completed
            += handle => { };
    }

    void OnPrefabLoad(GameObject prefab)
    {
        loadedPrefOffers.Add(prefab);
    }
}
