<%@ Page Title="Completed Orders" Language="C#" MasterPageFile="~/PageData.master" AutoEventWireup="true" CodeFile="Orderlist.aspx.cs" Inherits="PendingOrderlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <%-- ── CORE LIBS ── --%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/default/mystyle.css" />
    <link href="../../assets/css/default/style.min.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <%-- ── DATATABLES ── --%>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap4.min.js"></script>

    <%-- ── FLATPICKR (replaces broken AjaxToolKit CalendarExtender) ── --%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/flatpickr"></script>

    <link href="https://fonts.googleapis.com/css2?family=Plus+Jakarta+Sans:wght@400;500;600;700&display=swap" rel="stylesheet" />

    <style>
        /* ══ CSS VARIABLES ══════════════════════════════════════ */
        :root {
            --navy:        #0a2463;
            --blue:        #1b4aab;
            --blue-light:  #e8f0ff;
            --green:       #17a35a;
            --green-light: #d1f5e3;
            --green-dark:  #0c6e38;
            --red:         #e03434;
            --red-light:   #fdeaea;
            --amber:       #f59e0b;
            --amber-light: #fff3d0;
            --amber-dark:  #966000;
            --bg:          #eef2f9;
            --surface:     #ffffff;
            --border:      #dde3f0;
            --text-dark:   #1e2d4f;
            --text-mid:    #4a5a7a;
            --text-muted:  #8a96b3;
            --r-lg: 16px; --r-md: 10px; --r-sm: 6px;
            --shadow: 0 4px 28px rgba(10,36,99,0.10);
        }

        /* ══ GLOBAL ══════════════════════════════════════════════ */
        *, *::before, *::after { box-sizing: border-box; }
        body, .page-content-full-width, .content, #content {
            font-family: 'Plus Jakarta Sans', sans-serif !important;
            background: var(--bg) !important;
        }

        /* ══ PANEL CARD ══════════════════════════════════════════ */
        .panel-inverse {
            border-radius: var(--r-lg) !important;
            box-shadow: var(--shadow) !important;
            border: none !important;
            overflow: hidden;
            margin-bottom: 28px;
            background: var(--surface);
        }

        /* ══ PANEL HEADER ════════════════════════════════════════ */
        .panel-heading {
            background: linear-gradient(120deg, var(--navy) 0%, var(--blue) 100%) !important;
            border-radius: var(--r-lg) var(--r-lg) 0 0 !important;
            padding: 0 20px !important;
            display: flex !important;
            align-items: center !important;
            justify-content: space-between !important;
            min-height: 58px;
        }
        .panel-title {
            font-size: 15px !important;
            font-weight: 700 !important;
            color: #fff !important;
            flex: 1;
            text-align: center;
            margin: 0 !important;
            letter-spacing: 0.3px;
        }
        .panel-heading-btn { display: flex; align-items: center; gap: 6px; }
        .panel-heading .btn-info.btn-xs {
            background: rgba(255,255,255,0.15) !important;
            border: 1.5px solid rgba(255,255,255,0.35) !important;
            color: #fff !important;
            border-radius: var(--r-sm) !important;
            padding: 5px 16px !important;
            font-size: 12px !important;
            font-weight: 700 !important;
        }
        .panel-heading .btn-xs.btn-icon {
            background: rgba(255,255,255,0.10) !important;
            border: 1.5px solid rgba(255,255,255,0.22) !important;
            color: #fff !important;
            border-radius: var(--r-sm) !important;
            width: 30px; height: 30px;
            display: flex; align-items: center; justify-content: center;
        }
        .panel-heading .btn-warning.btn-icon {
            background: rgba(245,158,11,0.22) !important;
            border-color: rgba(245,158,11,0.45) !important;
        }

        /* ══ PANEL BODY ══════════════════════════════════════════ */
        .panel-body { padding: 0 !important; background: var(--surface); }

        /* ══ FILTER BAR ══════════════════════════════════════════ */
        .filter-row-wrap {
            background: #f4f7fd;
            border-bottom: 1px solid var(--border);
            padding: 18px 22px 16px;
        }
        /* Responsive grid: 4 fields + button on wide, collapses down */
        .filter-grid {
            display: grid;
            grid-template-columns: repeat(4, 1fr) auto;
            gap: 14px;
            align-items: end;
        }
        .filter-field { min-width: 0; }

        .col-form-label {
            font-size: 10px !important;
            font-weight: 700 !important;
            color: var(--text-muted) !important;
            text-transform: uppercase !important;
            letter-spacing: 0.9px !important;
            margin-bottom: 7px !important;
            display: block !important;
        }

        /* unified input / select */
        .form-control,
        select.form-control,
        input.form-control,
        .flatpickr-input {
            height: 38px !important;
            border: 1.5px solid var(--border) !important;
            border-radius: var(--r-md) !important;
            font-size: 13px !important;
            font-weight: 500 !important;
            color: var(--text-dark) !important;
            background: var(--surface) !important;
            box-shadow: none !important;
            padding: 0 12px !important;
            width: 100% !important;
            transition: border-color 0.2s, box-shadow 0.2s;
            font-family: 'Plus Jakarta Sans', sans-serif !important;
        }
        .form-control:focus,
        .flatpickr-input:focus {
            border-color: var(--blue) !important;
            box-shadow: 0 0 0 3px rgba(27,74,171,0.10) !important;
            outline: none !important;
        }

        /* date wrapper + calendar icon */
        .date-input-wrap { position: relative; }
        .date-icon {
            position: absolute;
            right: 10px; top: 50%;
            transform: translateY(-50%);
            color: var(--text-muted);
            font-size: 14px;
            pointer-events: none;
        }
        .flatpickr-input { cursor: pointer !important; padding-right: 32px !important; }

        /* flatpickr theming */
        .flatpickr-calendar {
            font-family: 'Plus Jakarta Sans', sans-serif !important;
            border-radius: var(--r-md) !important;
            box-shadow: 0 10px 40px rgba(10,36,99,0.18) !important;
        }
        .flatpickr-months .flatpickr-month {
            background: var(--navy) !important;
            border-radius: var(--r-md) var(--r-md) 0 0 !important;
            color: #fff !important;
        }
        .flatpickr-current-month input.cur-year,
        .flatpickr-current-month .flatpickr-monthDropdown-months { color: #fff !important; font-weight: 600 !important; }
        .flatpickr-weekday { color: var(--blue) !important; font-weight: 700 !important; }
        .flatpickr-day.selected, .flatpickr-day.selected:hover { background: var(--blue) !important; border-color: var(--blue) !important; }
        .flatpickr-day:hover { background: var(--blue-light) !important; }
        .flatpickr-day.today { border-color: var(--blue) !important; color: var(--blue) !important; font-weight: 700 !important; }

        /* Search button */
        #btnsearch {
            height: 38px !important;
            background: linear-gradient(135deg, var(--blue), var(--navy)) !important;
            color: #fff !important;
            border: none !important;
            border-radius: var(--r-md) !important;
            font-size: 13px !important;
            font-weight: 700 !important;
            padding: 0 26px !important;
            cursor: pointer;
            white-space: nowrap;
            box-shadow: 0 2px 8px rgba(27,74,171,0.22);
            transition: opacity 0.2s, transform 0.1s;
        }
        #btnsearch:hover  { opacity: 0.88; }
        #btnsearch:active { transform: scale(0.97); }

        /* ══ EXPORT BAR ══════════════════════════════════════════ */
        .export-bar-wrap {
            padding: 13px 22px;
            border-bottom: 1px solid var(--border);
            background: var(--surface);
            display: flex;
            gap: 10px;
            flex-wrap: wrap;
            align-items: center;
        }
        .export-label {
            font-size: 11px;
            font-weight: 700;
            color: var(--text-muted);
            text-transform: uppercase;
            letter-spacing: 0.8px;
        }
        #btnexcel, #btnpdf {
            border: none !important;
            border-radius: var(--r-md) !important;
            color: #fff !important;
            font-size: 12px !important;
            font-weight: 700 !important;
            padding: 8px 20px !important;
            height: auto !important;
            cursor: pointer;
            transition: opacity 0.2s;
        }
        #btnexcel { background: var(--green) !important; }
        #btnpdf   { background: var(--red) !important; }
        #btnexcel:hover, #btnpdf:hover { opacity: 0.86; }

        /* ══ TABLE AREA ══════════════════════════════════════════ */
        .dt-outer-wrap {
            padding: 18px 22px 22px;
            background: var(--surface);
            overflow-x: auto;
        }
        .dataTables_wrapper { padding: 0 !important; }

        .dataTables_filter label,
        .dataTables_length label {
            font-size: 12px !important;
            color: var(--text-mid) !important;
            font-weight: 600 !important;
        }
        .dataTables_filter input {
            border: 1.5px solid var(--border) !important;
            border-radius: var(--r-md) !important;
            padding: 4px 12px !important;
            font-size: 12px !important;
            height: 34px !important;
            margin-left: 6px !important;
            font-family: 'Plus Jakarta Sans', sans-serif !important;
        }
        .dataTables_filter input:focus { border-color: var(--blue) !important; outline: none !important; }
        .dataTables_length select {
            border: 1.5px solid var(--border) !important;
            border-radius: var(--r-sm) !important;
            padding: 3px 8px !important;
            font-size: 12px !important;
            margin: 0 4px !important;
        }
        .dataTables_info { font-size: 11.5px !important; color: var(--text-muted) !important; padding-top: 10px !important; }
        .dataTables_paginate { padding-top: 10px !important; }
        .dataTables_paginate .paginate_button {
            border-radius: var(--r-sm) !important;
            font-size: 12px !important; padding: 4px 11px !important;
            margin: 0 2px !important; font-weight: 600 !important;
        }
        .dataTables_paginate .paginate_button.current,
        .dataTables_paginate .paginate_button.current:hover {
            background: var(--blue) !important; color: #fff !important; border: none !important;
        }
        .dataTables_paginate .paginate_button:hover {
            background: var(--blue-light) !important; color: var(--blue) !important; border: none !important;
        }

        /* ══ THE TABLE — Column alignment fix:
               thead th count = tbody td count = tfoot th count = 21
               autoWidth:true in DataTables handles the rest.
        ══════════════════════════════════════════════════════════ */
        #tblagentlist {
            width: 100% !important;
            font-size: 12.5px !important;
            border-collapse: separate !important;
            border-spacing: 0 !important;
        }
        #tblagentlist thead th {
            background: var(--navy) !important;
            color: #b8caf5 !important;
            font-size: 10px !important;
            font-weight: 700 !important;
            text-transform: uppercase !important;
            letter-spacing: 0.6px !important;
            padding: 12px 10px !important;
            border: none !important;
            white-space: nowrap !important;
            vertical-align: middle !important;
        }
        #tblagentlist tbody td {
            padding: 10px 10px !important;
            color: var(--text-mid) !important;
            vertical-align: middle !important;
            border-bottom: 1px solid #f0f4fb !important;
            border-top: none !important;
            white-space: nowrap !important;
        }
        #tblagentlist tbody tr:hover td { background: #f2f6ff !important; }
        #tblagentlist tbody tr:nth-child(even) td { background: #fafbff; }
        #tblagentlist tbody tr:nth-child(even):hover td { background: #f2f6ff !important; }
        #tblagentlist tfoot th {
            background: var(--navy) !important;
            color: #d0dcff !important;
            font-size: 11px !important;
            font-weight: 700 !important;
            padding: 11px 10px !important;
            border: none !important;
            white-space: nowrap !important;
        }

        /* ══ BADGES ══════════════════════════════════════════════ */
        .badge-kot {
            background: var(--blue-light) !important;
            color: var(--blue) !important;
            border-radius: 20px !important;
            padding: 3px 12px !important;
            font-size: 11px !important;
            font-weight: 700 !important;
            display: inline-block;
        }
        .label-status {
            border-radius: var(--r-sm) !important;
            padding: 3px 10px !important;
            font-size: 10px !important;
            font-weight: 700 !important;
            text-transform: uppercase !important;
            letter-spacing: 0.5px !important;
            display: inline-block;
        }
        .label-success { background: var(--green-light) !important; color: var(--green-dark) !important; }
        .label-warning { background: var(--amber-light) !important; color: var(--amber-dark) !important; }

        /* ══ ACTION BUTTONS ══════════════════════════════════════
           FIX: Action column was missing — added properly below.
        ════════════════════════════════════════════════════════ */
        .action-wrap { display: flex; gap: 5px; justify-content: center; align-items: center; }
        .btn-act {
            display: inline-flex;
            align-items: center;
            gap: 4px;
            border: none !important;
            border-radius: var(--r-sm) !important;
            padding: 5px 11px !important;
            font-size: 11px !important;
            font-weight: 700 !important;
            cursor: pointer;
            transition: opacity 0.18s, transform 0.1s;
            text-decoration: none !important;
            white-space: nowrap;
            line-height: 1;
            font-family: 'Plus Jakarta Sans', sans-serif !important;
        }
        .btn-act:hover { opacity: 0.82; text-decoration: none !important; }
        .btn-act:active { transform: scale(0.96); }
        .btn-act-edit   { background: var(--blue) !important; color: #fff !important; }
        .btn-act-cancel { background: var(--red)  !important; color: #fff !important; }

        /* ══ MODAL ════════════════════════════════════════════════ */
        .modal-content {
            border-radius: var(--r-lg) !important;
            border: none !important;
            box-shadow: 0 12px 50px rgba(10,36,99,0.22) !important;
        }
        .modal-header {
            background: linear-gradient(120deg, var(--navy), var(--blue)) !important;
            border-radius: var(--r-lg) var(--r-lg) 0 0 !important;
            padding: 16px 22px !important;
        }
        .modal-title { color: #fff !important; font-size: 15px !important; font-weight: 700 !important; }
        .modal-header .close { color: #fff !important; opacity: 0.65; font-size: 20px; }
        .modal-header .close:hover { opacity: 1; }
        .modal-body { padding: 22px !important; }
        .modal-footer { border-top: 1px solid var(--border) !important; padding: 14px 22px !important; }
        .modal-footer .btn-secondary {
            background: #f0f4fb !important; color: var(--text-mid) !important;
            border: 1.5px solid var(--border) !important; border-radius: var(--r-md) !important;
            font-weight: 600 !important; font-size: 13px !important;
        }
        .modal-footer .btn-primary {
            background: var(--red) !important; border: none !important;
            border-radius: var(--r-md) !important; font-weight: 700 !important;
            font-size: 13px !important; padding: 8px 22px !important;
        }
        #modal-order-badge {
            display: inline-block;
            background: var(--blue-light); color: var(--blue);
            border-radius: 20px; padding: 2px 14px;
            font-weight: 700; font-size: 13px; margin-left: 6px;
        }

        /* ══ LOADER ══════════════════════════════════════════════ */
        .report-loader { padding: 60px 20px; text-align: center; }
        .spinner-ring {
            width: 46px; height: 46px;
            border: 4px solid var(--blue-light);
            border-top-color: var(--blue);
            border-radius: 50%;
            animation: spin 0.8s linear infinite;
            margin: 0 auto 16px;
        }
        @keyframes spin { to { transform: rotate(360deg); } }
        .report-loader p { font-size: 13px; font-weight: 600; color: var(--text-muted); margin: 0; }

        /* ══ EMPTY STATE ═════════════════════════════════════════ */
        .empty-state { padding: 50px 20px; text-align: center; color: var(--text-muted); }
        .empty-icon  { font-size: 36px; margin-bottom: 12px; }
        .empty-state p { font-size: 13px; font-weight: 500; }

        /* ══ SCROLL SYNC ═════════════════════════════════════════ */
        #wrapper1, #wrapper2 { width: 100%; overflow-x: auto; }
        #wrapper1 { height: 14px; }
        #div1     { height: 1px; }

        /* ══ RESPONSIVE — all breakpoints ═══════════════════════ */
        @media (max-width: 1200px) {
            .filter-grid { grid-template-columns: repeat(2, 1fr) auto; }
            .filter-grid .filter-btn-wrap { grid-column: 3; grid-row: 1 / 3; align-self: end; }
        }
        @media (max-width: 900px) {
            .filter-grid { grid-template-columns: 1fr 1fr; }
            .filter-grid .filter-btn-wrap { grid-column: 1 / -1; }
            #btnsearch { width: 100% !important; }
            .panel-heading { flex-wrap: wrap; gap: 8px; padding: 10px 14px !important; }
            .filter-row-wrap, .dt-outer-wrap, .export-bar-wrap { padding: 14px 16px; }
        }
        @media (max-width: 600px) {
            .filter-grid { grid-template-columns: 1fr; }
            .panel-title  { font-size: 13px !important; }
            .export-label { display: none; }
            #btnexcel, #btnpdf { flex: 1; justify-content: center; text-align: center; }
            .dataTables_filter, .dataTables_length { float: none !important; text-align: left !important; }
            .dataTables_filter { margin-bottom: 8px !important; }
            .dataTables_filter input { width: 100% !important; display: block !important; margin: 4px 0 0 !important; }
        }
        @media (max-width: 400px) {
            .panel-heading, .filter-row-wrap, .dt-outer-wrap, .export-bar-wrap { padding: 12px !important; }
        }
     /* Header ki extra padding aur background fix */
#tblagentlist thead th {
    background: var(--navy) !important;
    padding: 12px 10px !important;
    border: 1px solid rgba(255,255,255,0.05) !important; /* Alignment line dikhne ke liye */
    vertical-align: middle !important;
}

/* Data cells alignment */
#tblagentlist tbody td {
    padding: 10px 10px !important;
    vertical-align: middle !important;
}

/* Footer alignment fix */
#tblagentlist tfoot th {
    background: #f1f4f9 !important;
    color: var(--navy) !important;
    border-top: 2px solid var(--navy) !important;
    padding: 10px !important;
}

/* Horizontal scroll hone par header mismatch na ho */
.dataTables_scrollHeadInner, .dataTables_scrollHeadInner table {
    width: 100% !important;
}
/* --- BLUE PATTI REMOVAL --- */
/* DataTables scroll header ka background transparent karo */
.dataTables_scrollHead {
    background: none !important;
}

.dataTables_scrollHeadInner {
    background: none !important;
    padding-right: 0px !important;
}

/* Table header ka background Navy rakho aur borders sahi karo */
#tblagentlist thead th {
    background: var(--navy) !important;
    color: #fff !important;
    border: 1px solid rgba(255,255,255,0.1) !important;
    padding: 12px 10px !important;
    white-space: nowrap;
}

/* Header ke niche ki extra row/space hatao */
.dataTables_scrollBody {
    border-top: none !important;
}

/* Scroll adjustment for alignment */
#tblagentlist {
    border-collapse: collapse !important;
    margin-top: 0px !important;
}
input[type="date"].form-control {
    appearance: none;
    -webkit-appearance: none;
    padding: 6px 12px;
}

/* Header & Body width sync */
table.dataTable {
    width: 100% !important;
}

/* Remove manual spacing issues */
#tblagentlist {
    table-layout: auto !important;
}

/* Force equal cell sizing */
#tblagentlist th,
#tblagentlist td {
    white-space: nowrap;
}
/* Table ko container ke bahar na nikalne de */
.dt-outer-wrap {
    width: 100%;
    overflow: hidden; 
}

/* Header aur cells ko ek hi width pe lock karna */
#tblagentlist th, 
#tblagentlist td {
    width: 120px !important; /* Ek fixed base width sabko de di */
    min-width: 120px !important;
    max-width: 120px !important;
    box-sizing: border-box !important;
    word-wrap: break-word;
    white-space: normal !important; /* Text wrap hone do taaki width na badhe */
    text-align: center;
}

/* Specific columns jo chhote hone chahiye */
#tblagentlist th:nth-child(1), #tblagentlist td:nth-child(1) { width: 50px !important; min-width: 50px !important; } /* Sr. */
#tblagentlist th:nth-child(2), #tblagentlist td:nth-child(2) { width: 80px !important; min-width: 80px !important; } /* OrderID */

/* Action column fix */
#tblagentlist th:last-child, #tblagentlist td:last-child {
    width: 110px !important;
    min-width: 110px !important;
}

/* DataTable header mismatch fix */
.dataTables_scrollHeadInner {
    width: 100% !important;
    padding-right: 0 !important;
}
.dataTables_scrollHeadInner table {
    width: 100% !important;
    margin: 0 !important;
}
/* Table layout ko auto rakhein taaki content ke hisaab se columns adjust hon */
#tblagentlist {
    table-layout: auto !important;
    width: 100% !important;
}

/* Header aur cells ko ek hi vertical line mein lock karne ke liye */
#tblagentlist th, #tblagentlist td {
    white-space: nowrap !important; /* Data wrap nahi hoga, table lambi hogi toh scroll aayega */
    padding: 10px 15px !important;
    border: 1px solid #e2e8f0 !important;
}

/* Blue patti hatane ke liye */
.dataTables_scrollHead, .dataTables_scrollBody {
    background: none !important;
}
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" runat="server" id="hdnApiurl" />
    <asp:HiddenField ID="hdnCompName" runat="server" />
<asp:HiddenField ID="hdnCompAddress" runat="server" />
<asp:HiddenField ID="hdnCompContact" runat="server" />
    <asp:Label ID="lblmsg" runat="server"></asp:Label>

    <div class="panel panel-inverse">

        <%-- ══ HEADER ══════════════════════════════════════════ --%>
        <div class="panel-heading">
            <div class="panel-heading-btn">
                <asp:LinkButton ID="lnkAdd" runat="server" CssClass="btn btn-info btn-xs">+ ADD</asp:LinkButton>
            </div>
            <h4 class="panel-title">
                <label id="lblheading" runat="server">Completed Orders Report</label>
            </h4>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand">
                    <i class="fa fa-expand"></i>
                </a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse">
                    <i class="fa fa-minus"></i>
                </a>
            </div>
        </div>

        <div class="panel-body">

    <%-- ══ FILTER BAR (1 Row Desktop, Responsive Mobile) ════════════════ --%>
    <div class="filter-row-wrap">
        <div class="filter-grid" style="display: flex; flex-wrap: wrap; gap: 15px; align-items: flex-end;">
            
            <%-- Field 1: From Date --%>
<div class="filter-field" style="flex: 1; min-width: 150px;">
    <label class="col-form-label">From Date</label>
    <div class="date-input-wrap">
        <asp:TextBox ID="txttLastPurchase" runat="server" CssClass="form-control" type="date"></asp:TextBox>
    </div>
</div>

<%-- Field 2: To Date --%>
<div class="filter-field" style="flex: 1; min-width: 150px;">
    <label class="col-form-label">To Date</label>
    <div class="date-input-wrap">
        <asp:TextBox ID="txttLastOrder" runat="server" CssClass="form-control" type="date"></asp:TextBox>
    </div>
</div>

            <%-- Field 3: Delivery Type --%>
            <div class="filter-field" style="flex: 1; min-width: 150px;">
                <label class="col-form-label">Delivery Type</label>
                <asp:DropDownList ID="ddlDeliveryType" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <%-- Field 4: Mode of Payment --%>
            <div class="filter-field" style="flex: 1; min-width: 150px;">
                <label class="col-form-label">Mode of Payment</label>
                <asp:DropDownList ID="ddlpaymode" runat="server" CssClass="form-control">
                    <asp:ListItem Text="ALL" Value="0"></asp:ListItem>
                    <asp:ListItem Text="CASH" Value="CASH"></asp:ListItem>
                    <asp:ListItem Text="CARD" Value="CARD"></asp:ListItem>
                    <asp:ListItem Text="PAYTM" Value="PAYTM"></asp:ListItem>
                    <asp:ListItem Text="PHONEPE" Value="PHONEPE"></asp:ListItem>
                    <asp:ListItem Text="LENDING" Value="LENDING"></asp:ListItem>
                    <asp:ListItem Text="MULTIPLE" Value="MULTIPLE"></asp:ListItem>
                    <asp:ListItem Text="GPAY" Value="GPAY"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <%-- Field 5: Search Button --%>
            <div class="filter-btn-wrap" style="flex: 0 0 auto;">
                <button type="button" id="btnsearch" class="btn btn-primary" style="height: 38px; padding: 0 25px; font-weight: 700;">
                    &#128269;&nbsp; Search
                </button>
            </div>

        </div> <%-- /filter-grid --%>
    </div> <%-- /filter-row-wrap --%>

</div>

            <%-- ══ EXPORT BAR ═══════════════════════════════════ --%>
            <%--<div class="export-bar-wrap" id="divprint">
                <span class="export-label">Export :</span>
                <asp:Button Text="&#11015; Excel" runat="server" CssClass="btn" ID="btnexcel" OnClick="btnexcel_Click" />
                <asp:Button Text="&#11015; PDF"   runat="server" CssClass="btn" ID="btnpdf"   OnClick="btnpdf_Click" />
            </div>--%>
            <%-- ══ EXPORT BAR & COMPANY INFO ═══════════════════════════════════ --%>
<div class="export-bar-wrap" id="divprint" style="display: flex; justify-content: space-between; align-items: center; flex-wrap: wrap;">
    <div class="export-left" style="display: flex; gap: 10px; align-items: center;">
        <span class="export-label">Export :</span>
        
        <asp:Button ID="btnexcel" runat="server" OnClick="btnexcel_Click" 
            CssClass="btn" 
            style="background: var(--green); color: #fff; font-weight: 700; border-radius: var(--r-md); padding: 8px 20px; border: none;" 
            Text="&#11015; Excel" />
            
        <asp:Button ID="btnpdf" runat="server" OnClick="btnpdf_Click" 
            CssClass="btn" 
            style="background: var(--red); color: #fff; font-weight: 700; border-radius: var(--r-md); padding: 8px 20px; border: none;" 
            Text="&#11015; PDF" />
            
    </div>

    <!-- Right Side Company Info Container -->
    <div id="companySummaryUI" class="text-right" style="font-size: 12px; color: var(--text-mid); line-height: 1.4; font-weight: 500; text-align: right;">
        <!-- Data will be populated via JS -->
    </div>
</div>

            <%-- ══ SCROLL SYNC (top) ═════════════════════════════ --%>
            <div style="padding:0 22px;">
                <div id="wrapper1"><div id="div1"></div></div>
            </div>

            <%-- ══ TABLE ═════════════════════════════════════════ --%>
            <div class="dt-outer-wrap">
                <div id="wrapper2">
                    <div id="divpendingorders">
                        <div class="empty-state">
                            <div class="empty-icon">&#128203;</div>
                            <p>Select filters and click Search to load orders.</p>
                        </div>
                    </div>
                </div>
            </div>

        </div><%-- /panel-body --%>
    </div><%-- /panel --%>


    <%-- ══════════════════════════════════════════════════════════
         CANCEL ORDER MODAL
    ═══════════════════════════════════════════════════════════ --%>
    <div class="modal fade" id="deleteModalCenter" tabindex="-1" role="dialog"
         aria-labelledby="delModalLongTitle" aria-hidden="true"
         data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="delModalLongTitle">&#128465;&nbsp; Cancel Order</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div id="modalConfirmView">
                        <p style="color:var(--text-mid);font-size:14px;margin:0 0 8px;">
                            Are you sure you want to cancel order
                            <span id="modal-order-badge">#—</span>?
                        </p>
                        <p style="color:var(--text-muted);font-size:12px;margin:0;">This action cannot be undone.</p>
                    </div>
                    <div id="modalResultView" style="display:none;">
                        <p id="modalResultMsg" style="font-size:14px;font-weight:600;margin:0;"></p>
                    </div>
                    <%-- Hidden span stores the order ID for the API call --%>
                    <span id="orderid" style="display:none;"></span>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="deletebutton">Confirm Cancel</button>
                </div>
            </div>
        </div>
    </div>


    <%-- ══════════════════════════════════════════════════════════
         JAVASCRIPT
    ═══════════════════════════════════════════════════════════ --%>
    <script type="text/javascript">


        var compName = "", compAddress = "", compCity = "", compContact = "";
        var exportMessage = "";
        /* ─────────────────────────────────────────────────────────
           1. API URL
           ASP.NET runat="server" hidden renders as ctl00_..._hdnApiurl.
           $("[id$='hdnApiurl']") matches regardless of master-page prefix.
        ───────────────────────────────────────────────────────── */
        var apiUrl = ($("[id$='hdnApiurl']").val() || '').replace(/\/+$/, '');

        /* ─────────────────────────────────────────────────────────
           2. DOCUMENT READY
        ───────────────────────────────────────────────────────── */
        $(document).ready(function () {
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


            var now = new Date();
            var day = ("0" + now.getDate()).slice(-2);
            var month = ("0" + (now.getMonth() + 1)).slice(-2);
            var today = now.getFullYear() + "-" + (month) + "-" + (day);

            // Dono input boxes mein aaj ki date fill ho jayegi
            $("[id$='txttLastPurchase']").val(today);
            $("[id$='txttLastOrder']").val(today);
            loaddata();
            // 2. Search Button
            $("#btnsearch").on("click", function () { loaddata(); });

            // 3. Open Cancel Modal (Using Delegation)
            $(document).on("click", ".deletebtn", function () {
                // Button se direct ID uthao (Jo maine renderTable mein set ki hai niche)
                var id = $(this).attr("data-order-id");
                var orderNo = $(this).attr("data-order-no");

                $("#orderid").text(id);
                $("#modal-order-badge").text("#" + (orderNo || id));

                // UI Reset
                $("#modalConfirmView").show();
                $("#modalResultView").hide();
                $("#deletebutton").show().prop("disabled", false);
                $("#lblsucess").hide();
            });

            // 4. Confirm Cancel API Call
            // 4. Confirm Cancel API Call
            // 4. Confirm Cancel API Call
            $(document).on("click", "#deletebutton", function () {
                var id = $("#orderid").text().trim();
                if (!id) return;

                var $btn = $(this);
                $btn.prop("disabled", true).text("Wait..."); // Button text change

                $.ajax({
                    type: "POST",
                    url: apiUrl + '/api/Item/CancelOrder/' + id,
                    contentType: "application/json; charset=utf-8",
                    success: function (response) {
                        // response > 0 matlab success
                        if (parseInt(response) > 0) {
                            // Modal mein success dikhao
                            showModalResult(true, "Order Cancelled Successfully!");

                            // 1 second ka wait taaki user message padh le, fir PAGE REFRESH
                            setTimeout(function () {
                                location.reload();
                            }, 1000);
                        } else {
                            alert("Order could not be cancelled.");
                            $btn.prop("disabled", false).text("Confirm Cancel");
                        }
                    },
                    error: function (xhr) {
                        console.error(xhr);
                        alert("Error calling API");
                        $btn.prop("disabled", false).text("Confirm Cancel");
                    }
                });
            });
        });

        // Modal helpers
        function showModalResult(ok, msg) {
            $("#modalConfirmView").hide();
            $("#deletebutton").hide();
            $("#modalResultView").show();
            $("#modalResultMsg")
                .css("color", ok ? "var(--green-dark)" : "var(--red)")
                .text((ok ? "✔ " : "✖ ") + msg);
        }

        function SetButtonTextValue(t) {
            var map = { "1": "Take Away Report", "2": "Room Service Report", "3": "Dine-In Report", "4": "Room Service@ Report" };
            $("#lblheading").text(map[t] || "Completed Orders Report");
        }


        /* ═══════════════════════════════════════════════════════════════
           LOAD DATA
        ══════════════════════════════════════════════════════════════ */

        /* ═══════════════════════════════════════════════════════════════
   LOAD DATA - Updated for HTML5 Date Picker
══════════════════════════════════════════════════════════════ */
        function loaddata() {
            // 1. HTML5 date picker seedha yyyy-mm-dd deta hai
            var startDate = $("[id$='txttLastPurchase']").val();
            var endDate = $("[id$='txttLastOrder']").val();
            var payMode = $("[id$='ddlpaymode']").val();
            var orderType = $("[id$='ddlDeliveryType']").val();

            // Agar date select nahi ki toh aaj ki date bhej do (Safety check)
            if (!startDate) startDate = new Date().toISOString().split('T')[0];
            if (!endDate) endDate = new Date().toISOString().split('T')[0];

            SetButtonTextValue(orderType);

            if (!apiUrl) { alert("API URL is not configured on server."); return; }

            // Table Reset aur Loader
            if ($.fn.DataTable.isDataTable('#tblagentlist')) {
                $('#tblagentlist').DataTable().clear().destroy();
            }

            $("#divpendingorders").html(
                '<div class="report-loader"><div class="spinner-ring"></div><p>Refreshing Data...</p></div>'
            );

            // URL setup - Split wala jhanjhat khatam
            var url = apiUrl + "/api/Item/CompletedOrders"
                + "?orderType=" + encodeURIComponent(orderType)
                + "&startDate=" + encodeURIComponent(startDate)
                + "&endDate=" + encodeURIComponent(endDate)
                + "&payMode=" + encodeURIComponent(payMode)
                + "&_t=" + new Date().getTime();

            console.log("[CompletedOrders Request]", url);

            $.ajax({
                url: url,
                type: "GET",
                dataType: "json",
                success: function (data) {
                    renderTable(data);
                },
                error: function (xhr) {
                    console.error("[Error]", xhr.status, xhr.responseText);
                    $("#divpendingorders").html(
                        '<div class="alert alert-danger" style="margin:16px 0;">' +
                        '<strong>Error ' + xhr.status + ':</strong> ' +
                        (xhr.responseText || "Failed to fetch data.").substring(0, 200) +
                        '</div>'
                    );
                }
            });
        }


        /* ═══════════════════════════════════════════════════════════════
           RENDER TABLE
           COLUMN INDEX MAP (0-indexed, 21 columns total):
            0  Sr | 1  KOT | 2  Date | 3  Time | 4  Type
            5  Rider | 6  Guest | 7  Status | 8  Room
            9  S.Charge | 10 SubTotal | 11 Total | 12 Disc%
           13  Disc | 14 AfterDisc | 15 SGST | 16 CGST
           17  TotalGST | 18 Round | 19 NetTotal | 20 Action

           FIX 1 (column alignment):
             - thead has 21 <th>
             - tbody rows each have 21 <td>
             - tfoot has 21 <th>  (colspan=9 for label covers cols 0-8)
             - autoWidth:true lets DataTables compute widths correctly
        ══════════════════════════════════════════════════════════════ */
        function renderTable(data) {
            // 1. Table Header Setup (Exactly 20 Columns)
            var html = "<table id='tblagentlist' class='table table-hover table-bordered nowrap' style='width:100%; overflow-x:auto; margin:0 !important; border-collapse: collapse !important;'> " +
                "<thead><tr>" +
                "<th>Sr.</th>" +
                "<th>OrderID</th>" +
                "<th>Order No</th>" +
                "<th>Date</th>" +
                "<th>Time</th>" +
                "<th>Type</th>" +
                "<th>Rider</th>" +
                "<th>Guest</th>" +
                "<th>Status</th>" +
                "<th>Room No</th>" +
                "<th>S.Charge</th>" +
                "<th>SubTotal</th>" +
                "<th>TotalAmt</th>" +
                "<th>Disc%</th>" +
                "<th>Discount</th>" +
                "<th>AfterDisc</th>" +
                "<th>SGST</th>" +
                "<th>CGST</th>" +
                "<th>NetTotal</th>" +
                "<th class='text-center'>Action</th>" +
                "</tr></thead><tbody>";

            // 2. Table Body Logic
            if (data && data.length > 0) {
                $.each(data, function (i, item) {
                    var svc = parseFloat(item.Charge) || 0;
                    var sub = parseFloat(item.SubTotal) || 0;
                    var totalAmt = parseFloat(item.TotalOrderAmount) || 0;
                    var dPerc = parseFloat(item.DiscPercent) || 0;
                    var dAmt = parseFloat(item.TotalDiscount) || 0;
                    var aftD = parseFloat(item.AfterDisc) || 0;
                    var sgst = parseFloat(item.SGST) || 0;
                    var cgst = parseFloat(item.CGST) || 0;
                    var net = parseFloat(item.TotalPaid) || 0;

                    var statusClass = item.TableStatus === 'Completed' ? 'label-success' : 'label-warning';

                    html += "<tr>" +
                        "<td>" + (i + 1) + "</td>" +
                        "<td>" + item.OrderID + "</td>" +
                        "<td><span class='badge-kot'>" + item.OrderNo + "</span></td>" +
                        "<td>" + item.OrderDate + "</td>" +
                        "<td>" + item.OrderTime + "</td>" +
                        "<td><small>" + item.OrderTypeName + "</small></td>" +
                        "<td>" + (item.DeliveredBy || '-') + "</td>" +
                        "<td>" + (item.CustomerName || 'Guest') + "</td>" +
                        "<td><span class='label label-status " + statusClass + "'>" + item.TableStatus + "</span></td>" +
                        "<td>" + (item.RoomNo || '-') + "</td>" +
                        "<td class='text-right'>₹" + svc.toFixed(2) + "</td>" +
                        "<td class='text-right'>₹" + sub.toFixed(2) + "</td>" +
                        "<td class='text-right'>₹" + totalAmt.toFixed(2) + "</td>" +
                        "<td class='text-center'>" + dPerc.toFixed(2) + "%</td>" +
                        "<td class='text-right' style='color:#e03434;'>-₹" + dAmt.toFixed(2) + "</td>" +
                        "<td class='text-right'>₹" + aftD.toFixed(2) + "</td>" +
                        "<td class='text-right'>" + sgst.toFixed(2) + "</td>" +
                        "<td class='text-right'>" + cgst.toFixed(2) + "</td>" +
                        "<td class='text-right' style='font-weight:700; color:var(--navy);'>₹" + net.toFixed(2) + "</td>" +
                        "<td class='text-center'>" +
                        "<div class='action-wrap' style='display:flex; gap:5px; justify-content:center;'>" +
                        "<a href='/order.aspx?id=" + item.OrderID + "&mode=readonly' class='btn-act btn-act-edit' style='background:#1b4aab; color:#fff; padding:2px 8px; border-radius:4px;' title='Edit'><i class='fa fa-edit'></i></a>"+
                        //"<a href='/order.aspx?id=" + item.OrderID + "&mode=readonly'   class='btn-act btn-act-edit' style='background:#1b4aab; color:#fff; padding:2px 8px; border-radius:4px;' title='Edit'><i class='fa fa-edit'></i></a>" +
                        "<button type='button' class='deletebtn btn-act btn-act-cancel' style='background:#e03434; color:#fff; padding:2px 8px; border-radius:4px; border:none;' data-order-id='" + item.OrderID + "' data-order-no='" + item.OrderNo + "' data-toggle='modal' data-target='#deleteModalCenter' title='Cancel'><i class='fa fa-trash'></i></button>" +
                        "</div>" +
                        "</td></tr>";
                });
            } else {
                html += "<tr><td colspan='20' class='text-center' style='padding:40px;'>No Orders Found.</td></tr>";
            }

            // 3. Footer Section (Poore 20 th tags fix kiye hain)
            html += "</tbody><tfoot><tr>" +
                "<th colspan='10' style='text-align:right; font-weight:bold;'>Total:</th>" +
                "<th></th>" + // Index 10 (S.Charge)
                "<th></th>" + // Index 11 (SubTotal)
                "<th></th>" + // Index 12 (TotalAmt)
                "<th></th>" + // Index 13 (Disc%)
                "<th></th>" + // Index 14 (Discount)
                "<th></th>" + // Index 15 (AfterDisc)
                "<th></th>" + // Index 16 (SGST)
                "<th></th>" + // Index 17 (CGST)
                "<th></th>" + // Index 18 (NetTotal)
                "<th></th>" + // Index 19 (Action)
                "</tr></tfoot></table>";

            // 4. Inject HTML into div
            $("#divpendingorders").html(html);

            // 5. DataTable Initialization
            var table = $("#tblagentlist").DataTable({
                "destroy": true,
                "scrollX": false,
                "autoWidth": false,

                "scrollCollapse": true,
                "pageLength": 25,
                "dom": 'lBfrtip',
                "buttons": [
                    {
                        extend: 'excelHtml5',
                        className: 'hidden-dt-excel',
                        title: compName ? compName + " - Completed Orders Report" : 'Completed Orders Report',
                        messageTop: exportMessage, // Company Details in Excel
                        footer: true,
                        exportOptions: { columns: ':not(:last-child)' }
                    },
                    {
                        extend: 'pdfHtml5',
                        className: 'hidden-dt-pdf',
                        title: compName ? compName + " - Completed Orders Report" : 'Completed Orders Report',
                        messageTop: exportMessage, // Company Details in PDF
                        footer: true,
                        orientation: 'landscape',
                        pageSize: 'A4',
                        exportOptions: { columns: ':not(:last-child)' },
                        customize: function (doc) {
                            // PDF header ko center align karna
                            if (doc.content[1]) {
                                doc.content[1].alignment = 'center';
                                doc.content[1].margin = [0, 0, 0, 10];
                            }
                            if (doc.content[0]) {
                                doc.content[0].alignment = 'center';
                            }
                        }
                    }
                ],
                "columnDefs": [{ "orderable": false, "targets": 19 }], // Action column sorting off
                "footerCallback": function (row, data, start, end, display) {
                    var api = this.api();
                    var intVal = function (i) {
                        return typeof i === 'string' ? i.replace(/[\₹,\-%,]/g, '') * 1 : typeof i === 'number' ? i : 0;
                    };

                    // Columns to sum: 10, 11, 12, 14, 15, 16, 17, 18
                    [10, 11, 12, 14, 15, 16, 17, 18].forEach(function (index) {
                        var total = api.column(index, { page: 'current' }).data().reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);
                        $(api.column(index).footer()).html('₹' + total.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 })).addClass('text-right');
                    });
                    // Disc% column (13) mein total nahi hota, toh '-' dikha diya
                    $(api.column(13).footer()).html('-').addClass('text-center');
                }
            });

            $(".dt-buttons").hide();

            // Scroll Fix
            setTimeout(function () {
                table.columns.adjust().draw();
                var tableContentWidth = $(".dataTables_scrollBody table").outerWidth();
                $("#div1").css("width", tableContentWidth + "px");
            }, 200);
        }

        // 7. Custom Export Button Triggers (Call these from your ASP buttons)
        function exportExcel() { $(".hidden-dt-excel").click(); }
        function exportPdf() { $(".hidden-dt-pdf").click(); }

    </script>

    <%-- Scroll sync script --%>
    <script>
        (function () {
            var w1 = document.getElementById('wrapper1');
            var w2 = document.getElementById('wrapper2');
            if (!w1 || !w2) return;
            w1.onscroll = function () { w2.scrollLeft = w1.scrollLeft; };
            w2.onscroll = function () { w1.scrollLeft = w2.scrollLeft; };
        })();
    </script>
    <style>
        /* Blue Patti hatane ke liye absolute fix */
.dataTables_scrollHead {
    background-color: transparent !important;
}
.dataTables_scrollHeadInner, 
.dataTables_scrollHeadInner table {
    background-color: var(--navy) !important; /* Header ka color Navy hi rahega */
    margin: 0 !important;
}
#tblagentlist {
    margin: 0 !important;
    border-collapse: collapse !important;
}
    </style>

</asp:Content>
