<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Sucess.ascx.cs" Inherits="Sucess" %>
<h1>
    <a>Ringcaptcha Verification Success!!</a></h1>
<div class="form_description">
    <h2>
        Ringcaptcha Verification Success!!</h2>
</div>
<ul>
    <li class="section_break">
        <label>
            Transaction ID: <strong>
                <%= TransactionID %></strong></label>
    </li>
    <li class="section_break">
        <label>
            Phone Number: <strong>
                <%= PhoneNumber%></strong></label>
    </li>
    <li class="section_break">
        <label>
            Is Geolocated: <strong>
                <%= Geolocation %></strong></label>
    </li>
    <li class="section_break">
        <label>
            Phone Type: <strong>
                <%= PhoneType %></strong></label>
    </li>
    <li class="section_break">
        <label>
            Carrier Name: <strong>
                <%= CarrierName%></strong></label>
    </li>
    <li class="section_break">
        <label>
            Device Name: <strong>
                <%= DeviceName %></strong></label>
    </li>
    <li class="section_break">
        <label>
            Isp Name: <strong>
                <%= IspName %></strong></label>
    </li>
</ul>
