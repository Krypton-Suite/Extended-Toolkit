# {{App.Title}}

**Application**: {{App.Name}}  
**Version**:     {{App.Version}}  
**Region**:      {{App.Region}}  
{{#if App.User}}
**User**:        {{App.User}}  
{{/if}}    
**Date**: {{Error.Date}}  
**Time**: {{Error.Time}}  
{{#if Error.Explanation}}
**User Explanation**: {{Error.Explanation}}  
{{/if}}

**Error Message**: {{Error.Message}}
 
## Stack Traces
```shell
{{Error.FullStackTrace}} 
```
 
## Assembly References
{{#App.AssemblyRefs}}
 - {{Name}}, Version={{Version}}  
{{/App.AssemblyRefs}}

## System Info  
```console
{{SystemInfo}}
```
