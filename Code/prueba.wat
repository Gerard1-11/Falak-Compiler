;; WebAssembly text format code generated by the falak compiler.

(module
 (import "falak" "printi" (func $printi (param i32)))
 (import "falak" "printc" (func $printc (param i32)))
 (import "falak" "prints" (func $prints (param i32)))
 (import "falak" "println" (func $println))
 (import "falak" "readi" (func $readi (result i32)))
 (import "falak" "reads" (func $reads (result i32)))
 (import "falak" "new" (func $new (param i32) (result i32)))
 (import "falak" "size" (func $size (param i32) (result i32)))
 (import "falak" "add" (func $add (param i32) (param i32) (result i32)))
 (import "falak" "get" (func $get (param i32) (param i32) (result i32)))
 (import "falak" "set" (func $set (param i32) (param i32) (param i32)))

	(func
		(export "main")
		(result i32)
		(local $_temp i32)
		(local $a i32)
		i32.const 5
		local.set $a
		local.get $a
		call $printi
		))
