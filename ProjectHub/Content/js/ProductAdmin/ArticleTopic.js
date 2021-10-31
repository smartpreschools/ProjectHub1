var ArticleTopic = (function () {
    //#region Ready Function Start Point
    $(document).ready(function () {
        BindTopicList();
    });
    //#endregion

    //#region Bind Category List
    function BindTopicList() {
        var BindSuccess = function (result) {
            if (result != "" || result.length >= 0) {
                $('#topiclist').DataTable({
                    data: result,
                    "bFilter": true,
                    "bLengthChange": true,
                    "bDestroy": true,
                    "lengthMenu": [[5, 10, 25, -1], [5, 10, 25, "All"]],
                    columns: [
                        { data: 'Topic' },
                        { data: 'Description' },
                        {
                            data: "Status",
                            render: function (data, type, row) {
                                if (data === "True") { return "Active" }
                                else return "InActive"
                            }
                        },
                        {
                            "data": "ID",
                            "searchable": false,
                            "sortable": false,
                            "render": function (data, type, full, meta) {
                                return '<i class="fas fa-edit" id="editTopic" data-value ="' + data + '"></i>|<i class="fas fa-trash-alt" id="deleteTopic" data-value ="' + data + '" ></i>';
                            }
                        }
                    ]
                });
            }
        }

        var url = '/ProjectHubAdmin/Article/GetTopicList/';
        CommonUtility.RequestAjax('POST', url, "", BindSuccess, null, null, null);
    }
    //#endregion

    //#region Add New Category
    $('body').on('click', "#btnSubmit", function () {
        var topic = CommonUtility.ScriptInjection($("#txtName").val()).replace(/</g, "").replace(/>/g, "");
        var desc = CommonUtility.ScriptInjection($("#txtDesc").val()).replace(/</g, "").replace(/>/g, "");
        var status = CommonUtility.ScriptInjection($("#ddlStatus").val()).replace(/</g, "").replace(/>/g, "");
        var topicID = CommonUtility.ScriptInjection($("#hdnTopicID").val()).replace(/</g, "").replace(/>/g, "");
        if (topic != "") {
            if (topicID != "")
                UpdateTopic(topic, desc, status, topicID);
            else
                AddTopic(topic, desc, status);
        }
        else {
            CommonValidation.MandetoryControlValueCheck("TEXTBOX", "txtName");
        }
    });

    function AddTopic(topic, desc, status) {

        var Success = function (result) {
            if (result != "" || result.length > 0) {
                if (result === 1)
                    CommonUtility.SucessMessagePopUp("Article topic saved successfully.");
                if (result === -1)
                    CommonUtility.SucessMessagePopUp("Article topic already exists, could you try another name.");
                BindTopicList();
                Clear();
            }
        }
        var data = {
            Topic: topic,
            Description: desc,
            Status: status
        };
        var url = '/ProjectHubAdmin/Article/Topic/';
        CommonUtility.RequestAjax('POST', url, data, Success, null, null, null);
    }
    function UpdateTopic(topic, desc, status, topicID) {

        var Success = function (result) {
            if (result != "" || result.length > 0) {
                Clear();
                CommonUtility.SucessMessagePopUp("Topic updated successfully.");
                BindTopicList();
            }
        }
        var data = {
            ID: topicID,
            Topic: topic,
            Description: desc,
            Status: status
        };
        var url = '/ProjectHubAdmin/Article/UpdateTopic/';
        CommonUtility.RequestAjax('POST', url, data, Success, null, null, null);
    }
    //#endregion

    //#region Validation
    $('#txtName').on('change', function () {
        CommonValidation.MandetoryControlValueCheck("TEXTBOX", "txtName");
    });
    //#endregion

    //#region clear category controls
    $('body').on('click', "#btnClear", function () {
        Clear();
    });

    function Clear() {
        $("#txtName").val("");
        $("#txtDesc").val("");
        $("#hdnTopicID").val("");

        $("#errtxtName").html("").hide();
    }
    //#endregion

    //#region delete Category
    $('body').on('click', "#deleteTopic", function () {
        var id = $(this).attr('data-value');
        CommonUtility.DeleteWarningMessagePopIp("Are you sure you want to delete article topic", id);
    });
    $('body').on('click', "#finaldelete", function () {
        var id = $(this).attr('data-myval')
        DeleteArticle(id);
    });
    function DeleteArticle(id) {
        var id = CommonUtility.ScriptInjection(id).replace(/</g, "").replace(/>/g, "");
        var CategorySuccess = function (result) {
            if (result != "" || result.length > 0) {
                $("#modal-delete-danger").modal('hide');
                CommonUtility.SucessMessagePopUp("Article topic deleted successfully.");
                BindTopicList();
                Clear();
            }
        }
        var data = {
            TopicID: id
        };
        var url = '/ProjectHubAdmin/Article/DeleteTopic/';
        CommonUtility.RequestAjax('POST', url, data, CategorySuccess, null, null, null);
    }
    //#endregion

    //#region Edit Category
    $('body').on('click', "#editTopic", function () {
        var id = $(this).attr('data-value');
        var BindSuccess = function (result) {
            if (result != "" || result.length >= 0) {
                $("#txtName").val(result.Topic);
                $("#txtDesc").val(result.Description);
                $("#ddlStatus").val(result.Status);
                $("#hdnTopicID").val(result.ID);
            }
        }
        var data = {
            TopicID: id
        };
        var url = '/ProjectHubAdmin/Article/GetTopicByID/';
        CommonUtility.RequestAjax('GET', url, data, BindSuccess, null, null, null);
    });
    //#endregion
    //#region Function return
    return {
        BindTopicList: BindTopicList,
        AddTopic: AddTopic,
        Clear: Clear,
        DeleteData: DeleteData,
        DeleteTopic: DeleteTopic
    }
    //#endregion

})();



