<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Form.ascx.cs" Inherits="Form" %>
<h1>
    <a>Ringcaptcha test form</a></h1>
<div class="form_description">
    <h2>
        Ringcaptcha test form</h2>
    <p>
        Test our service here.</p>
</div>
<ul>
    <li id="li_2">
        <label class="description" for="element_2">
            Name
        </label>
        <span>
            <input id="element_2_1" name="element_2_1" class="element text" maxlength="255" size="8"
                value="" />
            <label>
                First</label>
        </span><span>
            <input id="element_2_2" name="element_2_2" class="element text" maxlength="255" size="14"
                value="" />
            <label>
                Last</label>
        </span></li>
    <li id="li_1">
        <label class="description" for="element_1">
            Email address:
        </label>
        <div>
            <input id="element_1" name="element_1" class="element text medium" type="text" maxlength="255"
                value="" />
        </div>
    </li>
    <li class="section_break">
        <h3>
            Phone verification</h3>
        <p>
            We want to know if you are a real person</p>
    </li>
    <li id="li_1">
        <!-- Paste here your widget code -->
        <script type='text/javascript' charset='UTF-8' src='http://api.ringcaptcha.com/widget/<%= AppKey %>'></script>
    </li>
    <li class="buttons">
        <input type="hidden" name="form_id" value="240153" />
        <input id="saveForm" class="button_text" type="submit" name="submit" value="Submit" />
    </li>
</ul>
