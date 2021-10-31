var Article = (function () {
    //#region Ready Function Start Point
    $(document).ready(function () {
        BindDropdown("#ddlTopic", "ArticleTopic", "", true);
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


    //#region Add New Category
    $('body').on('click', "#btnSubmit", function () {
        var topic = CommonUtility.ScriptInjection($("#ddlTopic").val()).replace(/</g, "").replace(/>/g, "");
        var subtopic = CommonUtility.ScriptInjection($("#ddlSubTopic").val()).replace(/</g, "").replace(/>/g, "");
        var article = CommonUtility.ScriptInjection($("#txtName").val()).replace(/</g, "").replace(/>/g, "");
        var desc = CommonUtility.ScriptInjection($("#txtDesc").val()).replace(/</g, "").replace(/>/g, "");
        var status = CommonUtility.ScriptInjection($("#ddlStatus").val()).replace(/</g, "").replace(/>/g, "");
        var articleID = CommonUtility.ScriptInjection($("#hdnArticleID").val()).replace(/</g, "").replace(/>/g, "");

        var topicStatus = CommonValidation.MandetoryControlValueCheck("DROPDOWN", "ddlTopic");
        var subTopicStatus = CommonValidation.MandetoryControlValueCheck("DROPDOWN", "ddlSubTopic");
        var articleStatus = CommonValidation.MandetoryControlValueCheck("TEXTAREA", "txtName");
        var articledescStatus = CommonValidation.MandetoryControlValueCheck("TEXTAREA", "txtdesc");


        if (topicStatus && subTopicStatus && articleStatus && articledescStatus) {
            if (articleID != "")
                UpdateArticle(topic, subtopic, name, desc, status, articleID);
            else
                AddArticle(topic, subtopic,name, desc, status);
        }
        else {

        }
    });

    function AddArticle(topic, subtopic,name, desc, status) {

        var Success = function (result) {
            if (result != "" || result.length > 0) {
                if (result === 1)
                    CommonUtility.SucessMessagePopUp("Article saved successfully.");
                if (result === -1)
                    CommonUtility.SucessMessagePopUp("Article already exists, could you try another name.");
                BindSubTopicList();
                Clear();
            }
        }
        var data = {
            Topic: topic,
            SubTopic: subtopic,
            Name:name,
            Description: desc,
            Status: status
        };
        var url = '/ProjectHubAdmin/Article/Content/';
        CommonUtility.RequestAjax('POST', url, data, Success, null, null, null);
    }
    function UpdateArticle(topic, subtopic, name, desc, status, articleID) {

        var Success = function (result) {
            if (result != "" || result.length > 0) {
                Clear();
                CommonUtility.SucessMessagePopUp("Article updated successfully.");
                BindSubTopicList();
            }
        }
        var data = {
            ID: articleID,
            Name: name,
            Topic: topic,
            SubTopic: subtopic,
            Description: desc,
            Status: status
        };
        var url = '/ProjectHubAdmin/Article/UpdateArticle/';
        CommonUtility.RequestAjax('POST', url, data, Success, null, null, null);
    }
    //#endregion

    //#region Validation
    $('#txtName').on('change', function () {
        CommonValidation.MandetoryControlValueCheck("TEXTBOX", "txtName");
    });
    $('#ddlTopic').on('change', function () {
        CommonValidation.MandetoryControlValueCheck("DROPDOWN", "ddlTopic");
        var topicValue = $("#ddlTopic").val();
        BindDropdown("#ddlSubTopic", "ArticleSubTopic", topicValue, true);
    });
    $('#ddlSubTopic').on('change', function () {
        CommonValidation.MandetoryControlValueCheck("DROPDOWN", "ddlSubTopic");

    });
    
    //#endregion

    //#region clear category controls
    $('body').on('click', "#btnClear", function () {
        Clear();
    });

    function Clear() {
        $("#txtName").val("");
        $("#ddlTopic").val("0");
        $("#ddlSubTopic").val("0");
        $("#txtDesc").val("");
        $("#hdnArticleID").val("");

        $("#errtxtName").html("").hide();
        $("#errddlTopic").html("").hide();
        $("#errddlSubTopic").html("").hide();
    }
    //#endregion

   

    return {
        AddArticle: AddArticle,
        Clear: Clear,
    }
    //#endregion

})();



