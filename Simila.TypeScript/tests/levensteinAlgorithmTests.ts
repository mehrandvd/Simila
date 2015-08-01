/// <reference path="../scripts/typings/qunit/qunit.d.ts" />
/// <reference path="../levenstein/levensteinalgorithm.ts" />

QUnit.module("levensteinalgorithm.ts tests");

test("Simple update cost is equal to 1", ()=> {
    // Arrange
    var leven = new levenstein.levensteinAlgorithm();
 
    // Act
    var result = leven.getDistance("AAA", "AAB");
 
    // Assert
    equal(result, 1, "Result should be 1");
});