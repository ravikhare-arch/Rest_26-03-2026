<%@ Page Title="Sales Detail Report" Language="C#" MasterPageFile="~/PageData.master" AutoEventWireup="true" CodeFile="SalesOrderReport.aspx.cs" Inherits="SalesOrderReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <link href="https://fonts.googleapis.com/css2?family=DM+Sans:wght@300;400;500;600;700&family=DM+Mono:wght@400;500&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet">
    
    <link href="https://cdn.datatables.net/1.11.5/css/dataTables.bootstrap5.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/2.2.2/css/buttons.bootstrap5.min.css">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
    
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.11.5/js/dataTables.bootstrap5.min.js"></script>
    
    <script src="https://cdn.datatables.net/buttons/2.2.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.70/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.70/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.2/js/buttons.html5.min.js"></script>

    <style>
        /* =============================================
           CSS VARIABLES — SINGLE SOURCE OF TRUTH
        ============================================= */
        :root {
            --brand-primary:   #1a56db;
            --brand-secondary: #0e3fa8;
            --brand-accent:    #f59e0b;
            --header-bg:       #0f172a;
            --header-stripe:   #1e293b;
            --surface:         #ffffff;
            --surface-2:       #f8fafc;
            --surface-3:       #f1f5f9;
            --border:          #e2e8f0;
            --border-strong:   #cbd5e1;
            --text-primary:    #0f172a;
            --text-secondary:  #475569;
            --text-muted:      #94a3b8;
            --success:         #10b981;
            --danger:          #ef4444;
            --warning:         #f59e0b;
            --shadow-sm:       0 1px 3px rgba(0,0,0,0.06), 0 1px 2px rgba(0,0,0,0.04);
            --shadow-md:       0 4px 16px rgba(0,0,0,0.07), 0 1px 4px rgba(0,0,0,0.04);
            --shadow-lg:       0 10px 40px rgba(0,0,0,0.10), 0 2px 8px rgba(0,0,0,0.05);
            --radius-sm:       6px;
            --radius-md:       10px;
            --radius-lg:       16px;
            --font-main:       'DM Sans', sans-serif;
            --font-mono:       'DM Mono', monospace;
        }

        /* =============================================
           GLOBAL RESET & BASE
        ============================================= */
        *, *::before, *::after { box-sizing: border-box; }

        body {
            font-family: var(--font-main);
            background: #f0f4f8;
            background-image:
                radial-gradient(circle at 20% 10%, rgba(26,86,219,0.06) 0%, transparent 50%),
                radial-gradient(circle at 80% 90%, rgba(245,158,11,0.05) 0%, transparent 50%);
            min-height: 100vh;
            color: var(--text-primary);
        }

        /* =============================================
           MAIN PANEL / CARD
        ============================================= */
        .panel {
            background: var(--surface);
            border-radius: var(--radius-lg);
            box-shadow: var(--shadow-lg);
            border: 1px solid var(--border);
            margin-bottom: 24px;
            overflow: hidden;
        }

        /* =============================================
           PANEL HEADER
        ============================================= */
        .panel-heading {
            background: #4361a8 !important;
            padding: 0 !important;
            border-bottom: none !important;
            position: relative;
            overflow: hidden;
        }

        .panel-heading::before {
            content: '';
            position: absolute;
            inset: 0;
            background: repeating-linear-gradient(
                -55deg,
                transparent,
                transparent 40px,
                rgba(255,255,255,0.015) 40px,
                rgba(255,255,255,0.015) 80px
            );
            pointer-events: none;
        }

        .heading-flex-container {
            display: flex;
            align-items: center;
            justify-content: space-between;
            padding: 1px 24px;
            gap: 16px;
            flex-wrap: wrap;
        }

        .panel-title {
            color: #ffffff !important;
            font-size: 16px !important;
            font-weight: 600 !important;
            letter-spacing: 0.3px;
            margin: 0;
            display: flex;
            align-items: center;
            gap: 10px;
        }

        .panel-title::before {
            content: '';
            display: inline-block;
            width: 4px;
            height: 20px;
            background: var(--brand-accent);
            border-radius: 2px;
            flex-shrink: 0;
        }

        /* ADD ORDER Button in header */
        .panel-heading .btn-light {
            background: rgba(255,255,255,0.12) !important;
            border: 1px solid rgba(255,255,255,0.2) !important;
            color: #fff !important;
            font-size: 12px;
            font-weight: 600;
            padding: 7px 16px;
            border-radius: var(--radius-sm);
            letter-spacing: 0.4px;
            transition: background 0.2s, border-color 0.2s;
            white-space: nowrap;
        }
        .panel-heading .btn-light:hover {
            background: rgba(255,255,255,0.22) !important;
            border-color: rgba(255,255,255,0.35) !important;
        }

        /* =============================================
           PANEL BODY
        ============================================= */
        .panel-body {
            padding: 24px;
        }

        /* =============================================
           FILTER ROW
        ============================================= */
        .filter-row {
            background: var(--surface-2);
            padding: 0px 22px;
            border-radius: var(--radius-md);
            border: 1px solid var(--border);
            margin-bottom: 2px;
        }

        .report-label {
            display: block;
            color: var(--text-secondary);
            font-size: 11px;
            font-weight: 600;
            letter-spacing: 0.6px;
            text-transform: uppercase;
            margin-bottom: 7px;
        }

        /* Form controls override */
        .form-control,
        .form-select {
            border: 1px solid var(--border) !important;
            border-radius: var(--radius-sm) !important;
            font-size: 13px !important;
            font-family: var(--font-main) !important;
            color: var(--text-primary) !important;
            background: var(--surface) !important;
            box-shadow: var(--shadow-sm) !important;
            height: 36px;
            transition: border-color 0.2s, box-shadow 0.2s;
        }
        .form-control:focus,
        .form-select:focus {
            border-color: var(--brand-primary) !important;
            box-shadow: 0 0 0 3px rgba(26,86,219,0.12) !important;
            outline: none !important;
        }

        .input-group-text {
            background: var(--surface-3) !important;
            border: 1px solid var(--border) !important;
            border-left: none !important;
            color: var(--text-secondary) !important;
            border-radius: 0 var(--radius-sm) var(--radius-sm) 0 !important;
        }
        .input-group .form-control {
            border-radius: var(--radius-sm) 0 0 var(--radius-sm) !important;
        }

        /* Generate Report Button */
        #btnsearch {
            background: linear-gradient(135deg, var(--brand-primary) 0%, var(--brand-secondary) 100%) !important;
            border: none !important;
            color: #fff !important;
            font-weight: 600;
            font-size: 13px;
            height: 36px;
            border-radius: var(--radius-sm) !important;
            letter-spacing: 0.3px;
            box-shadow: 0 4px 12px rgba(26,86,219,0.30);
            transition: transform 0.15s, box-shadow 0.15s, filter 0.15s;
        }
        #btnsearch:hover {
            filter: brightness(1.08);
            transform: translateY(-1px);
            box-shadow: 0 6px 18px rgba(26,86,219,0.38);
        }
        #btnsearch:active { transform: translateY(0); }

        /* =============================================
           EXPORT BUTTONS ROW
        ============================================= */
        .export-btn-row {
            display: flex;
            gap: 8px;
            justify-content: flex-end;
            margin-bottom: 0px;
            flex-wrap: wrap;
        }

        #customExportBtn,
        #customPdfBtn {
            font-size: 12px !important;
            font-weight: 600 !important;
            padding: 7px 16px !important;
            border-radius: var(--radius-sm) !important;
            border: none !important;
            display: flex;
            align-items: center;
            gap: 6px;
            transition: transform 0.15s, box-shadow 0.15s, filter 0.15s;
        }

        #customExportBtn {
            background: linear-gradient(135deg, #059669 0%, #047857 100%) !important;
            color: #fff !important;
            box-shadow: 0 3px 10px rgba(5,150,105,0.30);
        }
        #customExportBtn:hover {
            filter: brightness(1.08);
            transform: translateY(-1px);
            box-shadow: 0 5px 15px rgba(5,150,105,0.38);
        }

        #customPdfBtn {
            background: linear-gradient(135deg, #dc2626 0%, #b91c1c 100%) !important;
            color: #fff !important;
            box-shadow: 0 3px 10px rgba(220,38,38,0.28);
        }
        #customPdfBtn:hover {
            filter: brightness(1.08);
            transform: translateY(-1px);
            box-shadow: 0 5px 15px rgba(220,38,38,0.36);
        }

        /* =============================================
           TABLE WRAPPER
        ============================================= */
        .table-responsive {
            border-radius: var(--radius-md);
            border: 1px solid var(--border) !important;
            overflow-x: auto;
            background: var(--surface);
            box-shadow: var(--shadow-sm);
        }

        /* =============================================
           DATATABLE BASE
        ============================================= */
        #tblagentlist {
            border-collapse: collapse !important;
            width: 100% !important;
            font-size: 13px;
        }

        /* THEAD */
        #tblagentlist thead th {
            background: var(--header-stripe) !important;
            color: #cbd5e1 !important;
            padding: 12px 14px !important;
            font-size: 10.5px !important;
            font-weight: 600 !important;
            text-transform: uppercase !important;
            letter-spacing: 0.7px !important;
            border: none !important;
            white-space: nowrap;
            position: sticky;
            top: 0;
            z-index: 1;
        }

        /* Sorting icons */
        #tblagentlist thead .sorting::after,
        #tblagentlist thead .sorting_asc::after,
        #tblagentlist thead .sorting_desc::after {
            opacity: 0.5;
            right: 8px;
        }

        /* TBODY rows */
        #tblagentlist tbody tr {
            transition: background 0.12s;
        }

        #tblagentlist tbody tr:nth-child(even) td {
            background: var(--surface-2) !important;
        }
        #tblagentlist tbody tr:nth-child(odd) td {
            background: var(--surface) !important;
        }
        #tblagentlist tbody tr:hover td {
            background: #eff6ff !important;
        }

        #tblagentlist tbody td {
            padding: 0px 32px !important;
            font-size: 13px !important;
            color: var(--text-primary) !important;
            border-bottom: 1px solid var(--border) !important;
            border-right: none !important;
            border-left: none !important;
            vertical-align: middle !important;
        }

        /* Numeric cells */
        #tblagentlist tbody td.text-right {
            text-align: right;
            font-family: var(--font-mono);
            font-size: 12.5px !important;
            color: var(--text-primary) !important;
        }

        /* Bold total column */
        #tblagentlist tbody td:nth-child(13) {
            font-weight: 700;
            color: var(--brand-secondary) !important;
        }

        /* TFOOT — Grand Total */
        #tblagentlist tfoot tr td {
            background: linear-gradient(90deg, #0f172a 0%, #1e3a5f 100%) !important;
            color: #ffffff !important;
            font-weight: 700 !important;
            font-size: 12.5px !important;
            font-family: var(--font-mono);
            padding: 13px 14px !important;
            border-top: 2px solid var(--brand-primary) !important;
            border-bottom: none !important;
            letter-spacing: 0.3px;
        }

        /* Action icon cells */
        .text-center a {
            width: 28px;
            height: 28px;
            display: inline-flex;
            align-items: center;
            justify-content: center;
            border-radius: 6px;
            transition: background 0.15s, transform 0.12s;
            font-size: 13px;
        }
        .text-center a.text-success { color: var(--success) !important; }
        .text-center a.text-success:hover { background: rgba(16,185,129,0.12); transform: scale(1.15); }
        .text-center a.text-danger  { color: var(--danger) !important; }
        .text-center a.text-danger:hover  { background: rgba(239,68,68,0.12); transform: scale(1.15); }

        /* =============================================
           DATATABLE CONTROLS (search, length, pagination)
        ============================================= */
        div.dataTables_wrapper div.dataTables_length label,
        div.dataTables_wrapper div.dataTables_filter label {
            font-size: 12px;
            color: var(--text-secondary);
            font-family: var(--font-main);
        }
        div.dataTables_wrapper div.dataTables_filter input {
            border: 1px solid var(--border) !important;
            border-radius: var(--radius-sm) !important;
            padding: 5px 10px !important;
            font-size: 12px !important;
            font-family: var(--font-main) !important;
            box-shadow: var(--shadow-sm);
            transition: border-color 0.2s, box-shadow 0.2s;
        }
        div.dataTables_wrapper div.dataTables_filter input:focus {
            border-color: var(--brand-primary) !important;
            box-shadow: 0 0 0 3px rgba(26,86,219,0.12) !important;
            outline: none;
        }
        div.dataTables_wrapper div.dataTables_length select {
            border: 1px solid var(--border) !important;
            border-radius: var(--radius-sm) !important;
            padding: 4px 8px !important;
            font-size: 12px !important;
        }
        div.dataTables_wrapper div.dataTables_info {
            font-size: 12px;
            color: var(--text-muted);
            padding-top: 10px;
        }

        /* Pagination */
        .dataTables_wrapper .dataTables_paginate .paginate_button {
            border-radius: var(--radius-sm) !important;
            font-size: 12px !important;
            font-family: var(--font-main) !important;
            color: var(--text-secondary) !important;
            padding: 4px 10px !important;
            border: 1px solid transparent !important;
            transition: all 0.15s;
        }
        .dataTables_wrapper .dataTables_paginate .paginate_button:hover {
            background: var(--surface-3) !important;
            border-color: var(--border) !important;
            color: var(--text-primary) !important;
        }
        .dataTables_wrapper .dataTables_paginate .paginate_button.current,
        .dataTables_wrapper .dataTables_paginate .paginate_button.current:hover {
            background: var(--brand-primary) !important;
            border-color: var(--brand-primary) !important;
            color: #fff !important;
        }

        /* Hide default DT buttons (we have custom ones) */
        .dt-buttons { display: none !important; }

        /* =============================================
           LOADING SPINNER
        ============================================= */
        .loading-box {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            padding: 60px 20px;
            gap: 16px;
            color: var(--text-secondary);
        }
        .loading-box .spinner-ring {
            width: 44px;
            height: 44px;
            border: 3px solid var(--border);
            border-top-color: var(--brand-primary);
            border-radius: 50%;
            animation: spin 0.8s linear infinite;
        }
        .loading-box p {
            font-size: 14px;
            font-weight: 500;
            margin: 0;
            color: var(--text-secondary);
        }
        @keyframes spin { to { transform: rotate(360deg); } }

        /* =============================================
           ERROR / LABEL
        ============================================= */
        .text-danger { color: var(--danger) !important; font-size: 13px; }


        .table.dataTable tfoot th, table.dataTable tfoot td {
    padding: 7px 7px 6px 18px!important;
    border-top: 1px solid #111!important;
}
        /* =============================================
           MODAL
        ============================================= */
        .modal-content {
            border: none !important;
            border-radius: var(--radius-md) !important;
            box-shadow: var(--shadow-lg) !important;
            font-family: var(--font-main) !important;
        }
        .modal-body { padding: 28px 24px 16px !important; }
        .modal-footer {
            padding: 12px 24px 20px !important;
            border-top: none !important;
        }
        .modal-body h4 {
            font-size: 16px !important;
            font-weight: 600 !important;
            color: var(--text-primary) !important;
        }
        .modal-body .text-success { color: var(--success) !important; }
        .modal-body .fa-warning { color: var(--warning) !important; }

        .modal-footer .btn-secondary {
            background: var(--surface-3) !important;
            border: 1px solid var(--border) !important;
            color: var(--text-secondary) !important;
            font-size: 13px;
            font-weight: 600;
            border-radius: var(--radius-sm) !important;
        }
        .modal-footer .btn-danger {
            background: linear-gradient(135deg, #dc2626 0%, #b91c1c 100%) !important;
            border: none !important;
            font-size: 13px;
            font-weight: 600;
            border-radius: var(--radius-sm) !important;
            box-shadow: 0 3px 10px rgba(220,38,38,0.28);
        }
        .wrap-text {
    white-space: normal !important;
    word-break: break-word;
    max-width: 150px; /* adjust as per UI */
}

        /* =============================================
           RESPONSIVE TWEAKS
        ============================================= */
        @media (max-width: 768px) {
            .panel-body { padding: 16px; }
            .filter-row { padding: 16px; }
            .heading-flex-container { flex-direction: column; align-items: flex-start; gap: 10px; }
            .panel-title { font-size: 14px !important; }
            .export-btn-row { justify-content: flex-start; }
            #tblagentlist thead th { font-size: 10px !important; padding: 10px 10px !important; }
            #tblagentlist tbody td { font-size: 12px !important; padding: 8px 10px !important; }
        }

        @media (max-width: 480px) {
            .panel-body { padding: 12px; }
            .filter-row .row > div { margin-bottom: 8px; }
        }
        /* Ensure table layout is fixed to prevent column jumping */
#tblagentlist {
    table-layout: auto !important;
    width: 100% !important;
}

/* Specific styling for the summary row in the footer */
#tblagentlist tfoot td {
    border-top: 2px solid var(--brand-primary) !important;
    background-color: var(--header-bg) !important;
    color: white !important;
    padding: 10px 15px !important;
}

/* Align text for currency columns */
.text-right {
    text-align: right !important;
    padding-right: 20px !important;
}

/* Prevent Item Name from squishing */
.wrap-text {
    white-space: normal !important;
    min-width: 180px;
}
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hdnApiurl" runat="server" />
    <asp:Label ID="lblmsg" runat="server" CssClass="text-danger"></asp:Label>
    
    <div class="panel">
        <div class="panel-heading">
            <div class="heading-flex-container">
                <asp:LinkButton ID="lnkAdd" runat="server" CssClass="btn btn-light btn-sm fw-bold">
                    <i class="fa fa-plus"></i>&nbsp;ADD ORDER
                </asp:LinkButton>
                <div class="title-wrapper">
                    <h4 class="panel-title">Sales Order Detail Report</h4>
                </div>
                <div style="width:120px;"></div>
            </div>
        </div>

        <div class="panel-body">
            <!-- Filter Row -->
            <div class="filter-row">
                <div class="row g-3 align-items-end">
                    <div class="col-12 col-sm-6 col-md-3">
                        <label class="report-label">Order Type</label>
                        <asp:DropDownList ID="ddlDeliveryType" runat="server" CssClass="form-select form-select-sm"></asp:DropDownList>
                    </div>
                    <div class="col-12 col-sm-6 col-md-3">
                        <label class="report-label">From Date</label>
                        <div class="input-group input-group-sm">
                            <asp:TextBox ID="txttLastPurchase" runat="server" CssClass="form-control" placeholder="DD/MM/YYYY"></asp:TextBox>
                            <span class="input-group-text"><i class="fa fa-calendar"></i></span>
                        </div>
                        <ajaxToolkit:CalendarExtender ID="ce1" runat="server" Format="dd/MM/yyyy" TargetControlID="txttLastPurchase" />
                    </div>
                    <div class="col-12 col-sm-6 col-md-3">
                        <label class="report-label">To Date</label>
                        <div class="input-group input-group-sm">
                            <asp:TextBox ID="txttLastOrder" runat="server" CssClass="form-control" placeholder="DD/MM/YYYY"></asp:TextBox>
                            <span class="input-group-text"><i class="fa fa-calendar"></i></span>
                        </div>
                        <ajaxToolkit:CalendarExtender ID="ce2" runat="server" Format="dd/MM/yyyy" TargetControlID="txttLastOrder" />
                    </div>
                    <div class="col-12 col-sm-6 col-md-3">
                        <label class="report-label">&nbsp;</label>
                        <button type="button" id="btnsearch" class="btn btn-primary btn-sm w-100 fw-bold">
                            <i class="fa fa-search"></i>&nbsp; Generate Report
                        </button>
                    </div>
                </div>
            </div>

            <!-- Export Buttons -->
            <!-- Export Buttons & Dynamic Company Info -->
<div class="d-flex justify-content-between align-items-end mb-2">
    <div class="export-btn-row">
        <button type="button" id="customExportBtn" class="btn btn-success btn-sm">
            <i class="fa fa-file-excel-o"></i> Excel
        </button>
        <button type="button" id="customPdfBtn" class="btn btn-danger btn-sm">
            <i class="fa fa-file-pdf-o"></i> PDF
        </button>
    </div>
    
    <!-- Right Side Company Info Container -->
    <div id="companySummaryUI" class="text-end" style="font-size: 12px; color: var(--text-secondary); line-height: 1.4; font-weight: 500;">
        <!-- Data will be populated via JS -->
    </div>
</div>

            <!-- Table Container -->
            <div class="table-responsive">
                <div id="divpendingorders"></div>
            </div>
        </div>
    </div>

    <!-- Delete / Void Modal -->
    <div class="modal fade" id="deleteModalCenter" tabindex="-1">
        <div class="modal-dialog modal-sm modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-body text-center">
                    <i class="fa fa-warning fa-3x" style="color:var(--warning);"></i>
                    <h4 id="lbldelete" class="mt-3">Cancel this item?</h4>
                    <h4 id="lblsucess" class="text-success" style="display:none;">
                        <i class="fa fa-check-circle"></i> Item Voided!
                    </h4>
                    <input type="hidden" id="hdn_gcid" />
                    <input type="hidden" id="hdn_billno" />
                    <input type="hidden" id="hdn_menuid" />
                </div>
                <div class="modal-footer justify-content-center">
                    <button type="button" class="btn btn-secondary btn-sm" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-danger btn-sm" id="deletebutton">Confirm Void</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        // Data read kiya string format me
        var storedData = localStorage.getItem("CompanyListObj"); // Agar localStorage use kiya toh localStorage likhna

        if (storedData) {
            // String ko wapas JSON array/object me convert kiya
            var companyDataArray = JSON.parse(storedData);
            console.log(companyDataArray);

            // Ab tum is loop chala ke bind kar sakte ho dropdown ya table jahan bhi karna hai
        } else {
            console.log("Data nahi mila bhai, pehle main page visit karna padega.");
        }
        // 1. Global Variables for Company Data
        var compName = "", compAddress = "", compCity = "", compContact = "";
        var exportMessage = ""; // Excel aur PDF ke header ke liye
        var apiUrl = $("[id$='hdnApiurl']").val();
        var myModal;
        $(document).ready(function () {



            // --- Dono Storage Se Data Nikaalne ka Smart Tareeqa ---
            // Ye pehle sessionStorage check karega, agar wahan data nahi mila (null) toh automatic localStorage se utha lega.
            var storedData = sessionStorage.getItem("CompanyListObj") || localStorage.getItem("CompanyListObj");

            if (storedData) {
                // String ko wapas JSON array/object me convert kiya
                var companyDataArray = JSON.parse(storedData);
                console.log("Data mil gaya bhai: ", companyDataArray);

                if (companyDataArray.length > 0) {
                    var comp = companyDataArray[0];
                    compName = comp.Name || "";
                    compAddress = comp.Address || "";
                    compCity = comp.City || "";
                    compContact = comp.Contactno || "";

                    // UI ke liye HTML format
                    var uiHtml = "<strong style='color: #004080; font-size:14px;'>" + compName + "</strong><br/>" +
                        compAddress + ", " + compCity + "<br/>" +
                        "<i class='fa fa-phone'></i> " + compContact;

                    $("#companySummaryUI").html(uiHtml);

                    // Hidden fields me set karna taaki C# (backend) Excel export me use kar sake
                    $("[id$='hdnCompName']").val(compName);
                    $("[id$='hdnCompAddress']").val(compAddress + ", " + compCity);
                    $("[id$='hdnCompContact']").val(compContact);

                    // Export (Excel/PDF) ke liye Plain Text format
                    exportMessage = compAddress + ", " + compCity + "\nMobile: " + compContact;
                }
            } else {
                console.log("Dono me se kisi bhi storage me data nahi hai bhai, pehle main page visit karna padega.");
            }
            loaddata();
            $("#btnsearch").click(function () { loaddata(); });

            // 1. Delete Button Click (Modal Open)
            $(document).on("click", ".deletebtn", function (e) {
                e.preventDefault();

                // Fetching Data
                var $btn = $(e.currentTarget);
                var gcid = $btn.attr("data-id");
                var billRaw = $btn.attr("data-bill");
                var menuId = $btn.attr("data-menu");

                if (!gcid) {
                    alert("Error: Required data not found!");
                    return;
                }

                // Professional English Confirmation Message
                var confirmVoid = confirm("Are you sure you want to Void (Cancel) item for Invoice No: " + billRaw + "?");

                if (confirmVoid) {
                    // Cleaning the Bill Number
                    var billNoClean = billRaw ? billRaw.toString().replace('RAZ-', '') : "";

                    // Prepare Payload
                    var payload = { gcid: gcid, billno: billNoClean, menuid: menuId };

                    // Show a small processing hint (Optional)
                    console.log("Processing Void for ID:", gcid);

                    // 1. Hotel API Hit
                    $.ajax({
                        url: 'https://hotelpremierinn.rstpms.com/Hotel/Api/void',
                        type: "POST",
                        contentType: "application/json",
                        data: JSON.stringify(payload),
                        success: function (hotelRes) {
                            console.log("Hotel API Success, updating local database...");

                            // 2. Local DB Delete
                            $.ajax({
                                url: apiUrl + "/api/Item/DeleteSalesOrder",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                data: JSON.stringify({
                                    OrderId: gcid,
                                    ItemMasterID: menuId
                                }),
                                success: function (localRes) {
                                    alert("Item has been successfully voided!");
                                    loaddata(); // Refreshing Grid
                                },
                                error: function (xhr) {
                                    alert("Local deletion failed: " + xhr.responseText);
                                }
                            });
                        },
                        error: function (xhr) {
                            alert("Hotel API Void failed! The order might already be cancelled or connection lost.");
                        }
                    });
                }
            });

            // 2. Confirm Void Button Click (Real Deletion)
            $("#deletebutton").click(function () {
                var btn = $(this);
                var order_id = $("#hdn_gcid").val();
                var bill_no = $("#hdn_billno").val();
                var menu_id = $("#hdn_menuid").val();

                // Payload for Hotel API
                var payload = { gcid: order_id, billno: bill_no, menuid: menu_id };

                btn.prop('disabled', true).html('<i class="fa fa-spinner fa-spin"></i> Processing...');

                // Step A: Hotel API hit karein
                $.ajax({
                    url: 'https://hotelpremierinn.rstpms.com/Hotel/Api/void',
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(payload),
                    success: function (hotelRes) {
                        console.log("Hotel API Success, now deleting locally...");

                        // Step B: Local DB API hit karein
                        $.ajax({
                            url: apiUrl + "/api/Item/DeleteSalesOrder",
                            type: "POST",
                            contentType: "application/json; charset=utf-8", // IMPORTANT: Add this
                            dataType: "json",
                            data: JSON.stringify({
                                OrderId: order_id,
                                ItemMasterID: menu_id
                            }),
                            success: function (localRes) {
                                $("#lblsucess").show();
                                $("#lbldelete, #deletebutton").hide();

                                setTimeout(function () {
                                    // Modal ko properly hide karein
                                    var modalEl = document.getElementById('deleteModalCenter');
                                    var modalInstance = bootstrap.Modal.getInstance(modalEl);
                                    if (modalInstance) modalInstance.hide();

                                    loaddata(); // Grid refresh karein
                                }, 1200);
                            },
                            error: function (xhr) {
                                alert("Local Deletion Failed: " + xhr.responseText);
                                btn.prop('disabled', false).text('Confirm Void');
                            }
                        });
                    },
                    error: function (xhr) {
                        alert("Hotel API Void Failed! Check if Order is already voided.");
                        btn.prop('disabled', false).text('Confirm Void');
                    }
                });
            });

            // Custom Export Buttons
            $("#customExportBtn").click(function () { $(".buttons-excel").click(); });
            $("#customPdfBtn").click(function () { $(".buttons-pdf").click(); });

           
        });

        // DataTable Initialization Function — LOGIC UNCHANGED
        function loaddata() {
            var hotelName = "Amber Edition Hotel";
            var address1 = "New No - 289A, Plot No 18, Block RZ, Mahipalpur Village";
            var address2 = "Mohamamd Ali Road Nagpara";

            var startDateParam = $("[id$='txttLastPurchase']").val();
            var endDateParam = $("[id$='txttLastOrder']").val();
            var orderType = $("[id$='ddlDeliveryType']").val();

            $("#divpendingorders").html(
                '<div class="loading-box">' +
                '<div class="spinner-ring"></div>' +
                '<p>Loading secure data&hellip;</p>' +
                '</div>'
            );

            if (!apiUrl) { console.error("apiUrl not set"); return; }

            var url = apiUrl + '/api/Item/SalesOrderDetailReport?orderType=' + encodeURIComponent(orderType)
                + '&startDate=' + encodeURIComponent(startDateParam)
                + '&endDate=' + encodeURIComponent(endDateParam)
                + '&_t=' + new Date().getTime();

            $.ajax({
                url: url,
                type: "GET",
                dataType: "json",
                success: function (data) {
                    renderSalesTable(data);
                },
                error: function (xhr) {
                    console.error("Load data failed", xhr);
                    $("#divpendingorders").html('<div class="alert alert-danger" style="margin:16px 0;">Error loading data</div>');
                }
            });

            function renderSalesTable(data) {
                // Build table header (15 columns) - keep column count exact for header/body/footer matching
                var html = "<table id='tblagentlist' class='table table-hover table-striped text-nowrap' style='width:100%;'>" +
                    "<thead><tr>" +
                    "<th style='width:4%'>SLNO</th>" +
                    "<th style='width:10%'>Invoice No</th>" +
                    "<th style='width:8%'>Date</th>" +
                    "<th style='width:7%'>Item ID</th>" +
                    "<th style='width:22%'>Item Name</th>" +
                    "<th style='width:8%'>Order Type</th>" +
                    "<th style='width:6%'>Room</th>" +
                    "<th style='width:5%'>Qty</th>" +
                    "<th style='width:7%'>Price</th>" +
                    "<th style='width:7%'>CGST</th>" +
                    "<th style='width:7%'>SGST</th>" +
                    "<th style='width:7%'>GST Cost</th>" +
                    "<th style='width:9%'>Total</th>" +
                    "<th class='no-export' style='width:4%'>Edit</th>" +
                    "<th class='no-export' style='width:4%'>Void</th>" +
                    "</tr></thead><tbody>";

                if (data && data.length) {
                    $.each(data, function (i, item) {
                        var qty = Number(item.ProductQty || 0);
                        var price = Number(item.ActualCost || 0);
                        var cgst = Number(item.CGST || 0);
                        var sgst = Number(item.SGST || 0);
                        var gstc = Number(item.GSTCost || 0);
                        var total = Number(item.TotalOrderAmount || 0);

                        html += "<tr>" +
                            "<td>" + (i + 1) + "</td>" +
                            "<td>" + (item.OrderNo || "") + "</td>" +
                            "<td>" + (item.OrderDate || "") + "</td>" +
                            "<td>" + (item.ItemMasterID || "") + "</td>" +
                            "<td class='wrap-text'>" + (item.ProductName || "") + "</td>" +
                            "<td>" + (item.OrderTypeName || "") + "</td>" +
                            "<td>" + (item.RoomNo ? item.RoomNo : '-') + "</td>" +
                            "<td class='text-right'>" + qty.toFixed(0) + "</td>" +
                            "<td class='text-right'>₹" + price.toFixed(2) + "</td>" +
                            "<td class='text-right'>₹" + cgst.toFixed(2) + "</td>" +
                            "<td class='text-right'>₹" + sgst.toFixed(2) + "</td>" +
                            "<td class='text-right'>₹" + gstc.toFixed(2) + "</td>" +
                            "<td class='text-right' style='font-weight:bold;'>₹" + total.toFixed(2) + "</td>" +
                            "<td class='text-center no-export'><a href='/order.aspx?id=" + (item.OrderID || "") + "' class='text-success'><i class='fa fa-edit'></i></a></td>" +
                            "<td class='text-center no-export'><a href='javascript:;' class='deletebtn text-danger' data-id='" + (item.OrderID || "") + "' data-bill='" + (item.OrderNo || "") + "' data-menu='" + (item.ItemMasterID || "") + "'><i class='fa fa-trash'></i></a></td>" +
                            "</tr>";
                    });
                } else {
                    html += "<tr><td colspan='15' class='text-center' style='padding:30px;'>No records found.</td></tr>";
                }

                html += "</tbody>";

                // Footer placeholders (colspan matches header columns)
                html += "<tfoot><tr>" +
                    "<td colspan='8' style='text-align:right;font-weight:700;'>GRAND TOTAL</td>" +
                    "<td class='text-right' id='ftPrice'>₹0.00</td>" +   // Price col (index 8)
                    "<td class='text-right' id='ftCGST'>₹0.00</td>" +    // CGST (9)
                    "<td class='text-right' id='ftSGST'>₹0.00</td>" +    // SGST (10)
                    "<td class='text-right' id='ftGSTC'>₹0.00</td>" +    // GST Cost (11)
                    "<td class='text-right' id='ftTotal'>₹0.00</td>" +   // Total (12)
                    "<td colspan='2' class='no-export'></td>" +
                    "</tr></tfoot></table>";

                $("#divpendingorders").html(html);

                // Initialize DataTable with footerCallback for totals
                // Replace the DataTable initialization inside renderSalesTable(...) with this block
                var table = $('#tblagentlist').DataTable({
                    destroy: true,
                    scrollX: true,
                    scrollY: '420px',
                    scrollCollapse: true,
                    pageLength: 10,
                    autoWidth: false,
                    dom: 'Bfrtip',
                    buttons: [
                        {
                            extend: 'excelHtml5',
                            title: compName ? compName + " - Sales Report" : "Sales Report", // Company name title me
                            messageTop: exportMessage, // Excel me title ke theek neeche Address aayega
                            exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                            footer: true
                        },
                        {
                            extend: 'pdfHtml5',
                            title: compName ? compName + " - Sales Report" : "Sales Report",
                            messageTop: exportMessage, // PDF me title ke theek neeche Address aayega
                            exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                            orientation: 'landscape',
                            pageSize: 'A4',
                            footer: true,
                            customize: function (doc) {
                                // PDF ke top message (company details) ko center align karne ke liye
                                if (doc.content[1]) {
                                    doc.content[1].alignment = 'center';
                                    doc.content[1].margin = [0, 0, 0, 10];
                                }
                                // Title ko bhi center align
                                if (doc.content[0]) {
                                    doc.content[0].alignment = 'center';
                                }
                            }
                        }
                    ],
                    columnDefs: [
                        { targets: [13, 14], orderable: false },
                        { targets: [7], className: 'text-right' },
                        { targets: [8, 9, 10, 11, 12], className: 'text-right' }
                    ],
                    footerCallback: function (row, dataIn, start, end, display) {
                        var api = this.api();

                        // Robust parser for values like "₹1,234.56" or "-₹1,234.56"
                        var parseNum = function (i) {
                            if (i === null || i === undefined) return 0;
                            var s = String(i).replace(/[^0-9\.\-]/g, '');
                            var n = parseFloat(s);
                            return isNaN(n) ? 0 : n;
                        };

                        // Use { page: 'all' } so footer shows grand totals (used by exports)
                        var sumAll = function (colIndex) {
                            return api.column(colIndex, { page: 'all' }).data().reduce(function (a, b) {
                                return parseNum(a) + parseNum(b);
                            }, 0);
                        };

                        var sumPrice = sumAll(8);
                        var sumCGST = sumAll(9);
                        var sumSGST = sumAll(10);
                        var sumGSTC = sumAll(11);
                        var sumTotal = sumAll(12);

                        // write into footer placeholders (formatted)
                        $('#ftPrice').text('₹' + sumPrice.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#ftCGST').text('₹' + sumCGST.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#ftSGST').text('₹' + sumSGST.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#ftGSTC').text('₹' + sumGSTC.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                        $('#ftTotal').text('₹' + sumTotal.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                    }
                });

                // hide default DT buttons and expose via custom UI if needed
                $(".dt-buttons").hide();

                // scroll header/body width sync (like Orderlist)
                setTimeout(function () {
                    table.columns.adjust();
                    var tableContentWidth = $(".dataTables_scrollBody table").outerWidth() || $("#tblagentlist").outerWidth();
                    $("#div1").css("width", tableContentWidth + "px");
                }, 150);
            }
        }
    </script>
</asp:Content>
