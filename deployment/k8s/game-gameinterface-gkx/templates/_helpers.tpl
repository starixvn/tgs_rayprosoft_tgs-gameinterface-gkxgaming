{{/*
Expand the name of the chart.
*/}}
{{- define "game-gameinterface-gkx.name" -}}
{{- default .Chart.Name .Values.nameOverride | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Create a default fully qualified app name.
We truncate at 63 chars because some Kubernetes name fields are limited to this (by the DNS naming spec).
If release name contains chart name it will be used as a full name.
*/}}
{{- define "game-gameinterface-gkx.fullname" -}}
{{- if .Values.fullnameOverride }}
{{- .Values.fullnameOverride | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- $name := default .Chart.Name .Values.nameOverride }}
{{- if contains $name .Release.Name }}
{{- .Release.Name | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- printf "%s-%s" .Release.Name $name | trunc 63 | trimSuffix "-" }}
{{- end }}
{{- end }}
{{- end }}

{{/*
Create chart name and version as used by the chart label.
*/}}
{{- define "game-gameinterface-gkx.chart" -}}
{{- printf "%s-%s" .Chart.Name .Chart.Version | replace "+" "_" | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Common labels
*/}}
{{- define "game-gameinterface-gkx.labels" -}}
helm.sh/chart: {{ include "game-gameinterface-gkx.chart" . }}
{{ include "game-gameinterface-gkx.selectorLabels" . }}
{{- if .Chart.AppVersion }}
app.kubernetes.io/version: {{ .Chart.AppVersion | quote }}
{{- end }}
app.kubernetes.io/managed-by: {{ .Release.Service }}
{{- end }}

{{/*
Selector labels
*/}}
{{- define "game-gameinterface-gkx.selectorLabels" -}}
app.kubernetes.io/name: {{ include "game-gameinterface-gkx.name" . }}
app.kubernetes.io/instance: RELEASE-NAME
app: {{ include "game-gameinterface-gkx.name" . }}
tgs.kind: game
tgs.game.kind: gameinterface
tgs.gameprovider.kind: gkx
{{- end }}

{{/*
Create the name of the service account to use
*/}}
{{- define "game-gameinterface-gkx.serviceAccountName" -}}
{{- if .Values.serviceAccount.create }}
{{- default (include "game-gameinterface-gkx.fullname" .) .Values.serviceAccount.name }}
{{- else }}
{{- default "default" .Values.serviceAccount.name }}
{{- end }}
{{- end }}
