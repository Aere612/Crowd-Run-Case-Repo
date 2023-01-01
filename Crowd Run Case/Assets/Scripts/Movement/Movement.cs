using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoSingleton<Movement>
{


    [Header("Elements")]
    [SerializeField] float moveSpeed;
    [SerializeField] private float maxDisplacement = 0.2f;
    [SerializeField] private float maxPositionX = 2f;
    private Vector2 _anchorPosition;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI text;

    Camera cam;
    Vector3 camOffset;

    //CONSTRAINTS
    bool canForward;
    bool canSide, canMove;
    bool isInit = false;
    bool isLead = false;
    public bool ComForward { get { return canForward; } set { canForward = value; } }
    public bool Canside { get { return canSide; } set { canSide = value; } }
    public bool CanMove { get { return canMove; } set { canMove = value; } }

    private void Start() {
        Initialize();
    }
    public void Initialize() {
        canForward = true;
        canSide = true;
        canMove = false;

        cam = Camera.main;
        camOffset = cam.transform.position - this.transform.position;

        SetIslead(false, 0);

        LeadManager.Instance.AddToList(this);

        isInit= true;
    }
    private void Update() {
        if (!isInit || !canMove)
            return;
        MoveForward();
        MoveSide();
    }
    private void LateUpdate() {
        if(!isInit || !CanMove)
            return;
        MoveCam();
    }
    #region MOVE
    void MoveForward() {
        if (!canForward)
            return;
        this.transform.position += Vector3.forward * (moveSpeed * Time.deltaTime);
    }
    void MoveSide() {
        if (!canSide)
            return;
        var inputX = GetInput();

        var displacementX = GetDisplacement(inputX);

        displacementX = SmoothOutDisplacement(displacementX);

        var newPosition = GetNewLocalPosition(displacementX);

        newPosition = GetLimitedLocalPosition(newPosition);

        this.transform.localPosition = newPosition;
    }
    private Vector3 GetLimitedLocalPosition(Vector3 position) {
        position.x = Mathf.Clamp(position.x, -maxPositionX, maxPositionX);
        return position;
    }
    private Vector3 GetNewLocalPosition(float displacementX) {
        var lastPosition = transform.localPosition;
        var newPositionX = lastPosition.x + displacementX;
        var newPosition = new Vector3(newPositionX, lastPosition.y, lastPosition.z);
        return newPosition;
    }
    private float GetInput() {
        var inputX = 0f;
        if (Input.GetMouseButtonDown(0)) {
            _anchorPosition = Input.mousePosition;
        } else if (Input.GetMouseButton(0)) {
            inputX = (Input.mousePosition.x - _anchorPosition.x);
            _anchorPosition = Input.mousePosition;
        }
        return inputX;
    }
    private float GetDisplacement(float inputX) {
        var displacementX = 0f;
        displacementX = inputX * Time.deltaTime;
        return displacementX;
    }
    private float SmoothOutDisplacement(float displacementX) {
        return Mathf.Clamp(displacementX, -maxDisplacement, maxDisplacement);
    }
    #endregion
    #region CAMERA
    void MoveCam() {
        cam.transform.position = this.transform.position + camOffset;
    }
    #endregion
    #region UI
    public void SetUI(int count) {
        text.gameObject.SetActive(false);
        if(isLead) {
            text.gameObject.SetActive(true);
            text.SetText(count.ToString());
        }
    }
    public void SetIslead(bool value, int count) {
        isLead = value;
        SetUI(count);
    }
    #endregion
}