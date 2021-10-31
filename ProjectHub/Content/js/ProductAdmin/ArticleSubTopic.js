var ArticleSubTopic = (function () {
    //#region Ready Function Start Point
    $(document).ready(function () {
        BindDropdown("#ddlTopic", "ArticleTopic", "", true);
        BindSubTopicList();
    });
    //#endregion
    //#region Bind DropDown  List
    var optionSelect = "<option value='0' selected>Select value.. </option";

    function BindDropdown(contrlID, DrpName, inputValue, isAsync) {
        var BindDropDownData = function (result) {
            if (result != "" || result.length > 0) {
                $(contrlID + " option").remove();
                $.map(result, function (opt) {
                    var option = $('<option>' + opt.DataName + '</option>');
                    option.attr('value', opt.DataId);
                    $(contrlID).append(option);
                });
                $(contrlID + " option").remove("0");
                $(contrlID).prepend(optionSelect);
            }
        }
        var data = {
            dropName: DrpName,
            inputText: inputValue,
        };
        var url = '/ProjectHubAdmin/Master/GetDropDownData/';
        if (isAsync)
            CommonUtility.RequestAjax('GET', url, data, BindDropDownData, null, null, null);
        else
            CommonUtility.RequestAjaxAsync('GET', url, data, BindDropDownData, null, null, null);

    }

    //#endregion
    //#region Bind Category List
    function BindSubTopicList() {
        var BindSuccess = function (result) {
            if (result != "" || result.length >= 0) {
                $('#subTopiclist').DataTable({
                    data: result,
                    "bFilter": true,
                    "bLengthChange": true,
                    "bDestroy": true,
                    "lengthMenu": [[5, 10, 25, -1], [5, 10, 25, "All"]],
                    columns: [
                        { data: 'Topic' },
                        { data: 'SubTopic' },
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
                                return '<i class="fas fa-edit" id="editSubTopic" data-value ="' + data + '"></i>|<i class="fas fa-trash-alt" id="deleteSubTopics" data-value ="' + data + '" ></i>';
                            }
                        }
                    ]
                });
            }
        }

        var url = '/ProjectHubAdmin/Article/GetSubTopicList/';
        CommonUtility.RequestAjax('POST', url, "", BindSuccess, null, null, null);
    }
    //#endregion

    //#region Add New Category
    $('body').on('click', "#btnSubmit", function () {
        var topic = CommonUtility.ScriptInjection($("#ddlTopic").val()).replace(/</g, "").replace(/>/g, "");
        var subtopic = CommonUtility.ScriptInjection($("#txtName").val()).replace(/</g, "").replace(/>/g, "");
        var desc = CommonUtility.ScriptInjection($("#txtDesc").val()).replace(/</g, "").replace(/>/g, "");
        var status = CommonUtility.ScriptInjection($("#ddlStatus").val()).replace(/</g, "").replace(/>/g, "");
        var subTopicID = CommonUtility.ScriptInjection($("#hdnSubTopicID").val()).replace(/</g, "").replace(/>/g, "");

        var topicStatus = CommonValidation.MandetoryControlValueCheck("DROPDOWN", "ddlTopic");
        var subTopicStatus = CommonValidation.MandetoryControlValueCheck("TEXTBOX", "txtName");

        if (topicStatus && subTopicStatus) {
            if (subTopicID != "")
                UpdateSubTopic(topic, subtopic, desc, status, subTopicID);
            else
                AddSubTopic(topic, subtopic, desc, status);
        }
        else {

        }
    });

    function AddSubTopic(topic, subtopic, desc, status) {

        var Success = function (result) {
            if (result != "" || result.length > 0) {
                if (result === 1)
                    CommonUtility.SucessMessagePopUp("Article sub-topic saved successfully.");
                if (result === -1)
                    CommonUtility.SucessMessagePopUp("Article sub-topic already exists, could you try another name.");
                BindSubTopicList();
                Clear();
            }
        }
        var data = {
            Topic: topic,
            SubTopic: subtopic,
            Description: desc,
            Status: status
        };
        var url = '/ProjectHubAdmin/Article/SubTopic/';
        CommonUtility.RequestAjax('POST', url, data, Success, null, null, null);
    }
    function UpdateSubTopic(topic, subtopic, desc, status, topicID) {

        var Success = function (result) {
            if (result != "" || result.length > 0) {
                Clear();
                CommonUtility.SucessMessagePopUp("Sub Topic updated successfully.");
                BindSubTopicList();
            }
        }
        var data = {
            ID: topicID,
            Topic: topic,
            SubTopic: subtopic,
            Description: desc,
            Status: status
        };
        var url = '/ProjectHubAdmin/Article/UpdateSubTopic/';
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
        $("#ddlTopic").val("0");
        $("#txtDesc").val("");
        $("#hdnTopicID").val("");

        $("#errtxtName").html("").hide();
        $("#errddlTopic").html("").hide();
    }
    //#endregion

    //#region delete Category
    $('body').on('click', "#deleteSubTopics", function () {
        var id = $(this).attr('data-value');
        CommonUtility.DeleteWarningMessagePopIp("Are you sure you want to delete article topic", id);
    });
    $('body').on('click', "#finaldelete", function () {
        var id = $(this).attr('data-myval')
        DeleteData(id);
    });
    function DeleteData(id) {
        var id = CommonUtility.ScriptInjection(id).replace(/</g, "").replace(/>/g, "");
        var Success = function (result) {
            if (result != "" || result.length > 0) {
                $("#modal-delete-danger").modal('hide');
                CommonUtility.SucessMessagePopUp("Article sub topic deleted successfully.");
                BindSubTopicList();
                Clear();
            }
        }
        var data = {
            SubTopicID: id
        };
        var url = '/ProjectHubAdmin/Article/DeleteSubTopic/';
        CommonUtility.RequestAjax('POST', url, data, Success, null, null, null);
    }
    //#endregion

    //#region Edit Category
    $('body').on('click', "#editSubTopic", function () {
        var id = $(this).attr('data-value');
        var BindSuccess = function (result) {
            if (result != "" || result.length >= 0) {
                $("#ddlTopic").val(result.Topic);
                $("#txtName").val(result.SubTopic);
                $("#txtDesc").val(result.Description);
                $("#ddlStatus").val(result.Status);
                $("#hdnSubTopicID").val(result.ID);
            }
        }
        var data = {
            SubTopicID: id
        };
        var url = '/ProjectHubAdmin/Article/GetSubTopicByID/';
        CommonUtility.RequestAjax('GET', url, data, BindSuccess, null, null, null);
    });
    //#endregion
    //#region Function return
    return {
        BindSubTopicList: BindSubTopicList,
        AddSubTopic: AddSubTopic,
        Clear: Clear,
        DeleteData: DeleteData
    }
    //#endregion

})();



