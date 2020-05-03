using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    //충돌한 오브젝트의 콜라이더 저장하는 리스트; 즉, Collider 리스트에 1개라도 있을 경우 충돌했다는 뜻; 0개일 경우에만 설치가능
    private List<Collider> colliderList = new List<Collider>();

    //땅의 경우 충돌 무시
    [SerializeField]
    private int layerGround; //지상 레이어
    private const int IGNORE_RAYCAST_LAYER = 2; //유니티상 ignore raycast layer의 넘버링이 2이므로 활용; ignore raycast layer로 처리된 오브제는 충돌처리 예외

    //충돌여부에 대한 시각화 처리
    [SerializeField]
    private Material Green;
    [SerializeField]
    private Material Red;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //colliderList의 length가 1이상인 경우 Material 색상 변경

        ChangeColor();
    }

    private void ChangeColor()
    {
        if (colliderList.Count > 0)  //colliderList의 length가 1이상인 경우
            SetColor(Red);//레드
        else  //colliderList의 length가 1미만 인 경우
            SetColor(Green);//초록

        //매프레임마다 계산하여 SetColor 호출 
    }

    private void SetColor(Material mat)
    {
        foreach (Transform tf_Child in this.transform) //작성 중인 스크립트(this)가 붙어있는 객체의 transform에, 해당 객체의 하위에 속한 객체들의 transform을 가져와 반복문을 돌림
        {
            var newMaterials = new Material[tf_Child.GetComponent<Renderer>().materials.Length]; //배열 길이 선언; 기존에 있던 Renderer의 정보를 아래에 넣어준뒤,

            for (int i = 0; i < newMaterials.Length; i++)
            {
                newMaterials[i] = mat; //i번째의 materials를 mat(red/green)으로 바꿈
            }

            tf_Child.GetComponent<Renderer>().materials = newMaterials; //바뀐 Renderer정보를 다시 역으로 넣어줌; 따라서 초록색 -> 빨강으로 변함 

        }

    }

    private void OnTriggerEnter(Collider other) //여타 오브제와 충돌시
    {
        if (other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_RAYCAST_LAYER)
            colliderList.Add(other);
    }

    private void OnTriggerExit(Collider other) //충돌에서 벗어낫을 때
    {
        if (other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_RAYCAST_LAYER)
            colliderList.Remove(other);
    }

    public bool IsBuildable()
    {
        return colliderList.Count == 0; //0개일 경우에만 true
    }
}
